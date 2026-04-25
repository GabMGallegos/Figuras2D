using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class Pie : Shapes
    {
        public double Radius { get; set; }
        public double Angle { get; set; }

        public Pie(double radius, double angle)
        {
            Radius = radius;
            Angle = angle;
        }

        public override double CalculateArea()
        {
            return (Angle / 360) * Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            double arcLength = (Angle / 360) * 2 * Math.PI * Radius;

            return arcLength + (2 * Radius);
        }

        public override bool IsValid()
        {
            return Radius > 0 && Angle > 0 && Angle <= 360;
        }
    }
}
