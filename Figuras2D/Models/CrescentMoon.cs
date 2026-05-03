using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{

    public class CrescentMoon : Shapes
    {
        public double Radius { get; set; }

     
        private const double InnerRadiusFactor = 0.75;
        private const double OffsetFactor = 0.35;

        public CrescentMoon(double radius)
        {
            Radius = radius;
        }

        public double InnerRadius => Radius * InnerRadiusFactor;


        public double Offset => Radius * OffsetFactor;

        public override double CalculateArea()
        {
            double R = Radius;
            double r = InnerRadius;
            double d = Offset;

            double outerArea = Math.PI * R * R;
            double intersection = CircleIntersectionArea(R, r, d);

            return outerArea - intersection;
        }


        public override double CalculatePerimeter()
        {
            double R = Radius;
            double r = InnerRadius;
            double d = Offset;


            if (d >= R + r)
                return 2 * Math.PI * R;

            if (d + r <= R)
                return 2 * Math.PI * R;

            double cosAlpha = (d * d + R * R - r * r) / (2 * d * R);
            double cosBeta = (d * d + r * r - R * R) / (2 * d * r);

            cosAlpha = Math.Max(-1, Math.Min(1, cosAlpha));
            cosBeta = Math.Max(-1, Math.Min(1, cosBeta));

            double alpha = Math.Acos(cosAlpha);
            double beta = Math.Acos(cosBeta);

            double outerArc = R * (2 * Math.PI - 2 * alpha);
            double innerArc = r * 2 * beta;

            return outerArc + innerArc;
        }


        public override bool IsValid()
        {
            return Radius > 0;
        }


        private static double CircleIntersectionArea(double R, double r, double d)
        {
            
            if (d >= R + r)
                return 0;

           
            if (d + r <= R)
                return Math.PI * r * r;

            double cosAlpha = (d * d + R * R - r * r) / (2 * d * R);
            double cosBeta = (d * d + r * r - R * R) / (2 * d * r);

            cosAlpha = Math.Max(-1, Math.Min(1, cosAlpha));
            cosBeta = Math.Max(-1, Math.Min(1, cosBeta));

            double alpha = Math.Acos(cosAlpha);
            double beta = Math.Acos(cosBeta);

            return R * R * (alpha - Math.Sin(alpha) * Math.Cos(alpha))
                 + r * r * (beta - Math.Sin(beta) * Math.Cos(beta));
        }
    }
}