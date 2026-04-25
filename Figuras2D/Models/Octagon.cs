using System;

namespace Figuras2D.Models
{
    public class Octagon : Shapes
    {
        public double Side { get; set; }

        public Octagon(double side)
        {
            Side = side;
        }

        public override double CalculateArea()
        {
            return 2 * (1 + Math.Sqrt(2)) * Math.Pow(Side, 2);
        }

        public override double CalculatePerimeter()
        {
            return 8 * Side;
        }

        public override bool IsValid()
        {
            return Side > 0;
        }
    }
}
