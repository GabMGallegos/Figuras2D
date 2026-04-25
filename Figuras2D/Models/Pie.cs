using System;

namespace Figuras2D.Models
{
    public class Pie : Shapes
    {
        public double Radius { get; set; }
        public double StartAngle { get; set; }
        public double EndAngle { get; set; }

        public Pie(double radius, double startAngle, double endAngle)
        {
            Radius = radius;
            StartAngle = startAngle;
            EndAngle = endAngle;
        }

        private double CalculateVisibleAngle()
        {
            double angle = EndAngle - StartAngle;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }

        public override double CalculateArea()
        {
            double visibleAngle = CalculateVisibleAngle();
            return (visibleAngle / 360) * Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            double visibleAngle = CalculateVisibleAngle();
            double arcLength = (visibleAngle / 360) * 2 * Math.PI * Radius;
            return arcLength + 2 * Radius; // Arc length + 2 radii
        }

        public override bool IsValid()
        {
            return Radius > 0 && StartAngle >= 0 && StartAngle < 360 && EndAngle >= 0 && EndAngle < 360;
        }
    }
}
