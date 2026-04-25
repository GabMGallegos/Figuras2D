using System;

namespace Figuras2D.Models
{
    public class Rhombus : Shapes
    {
        public double DiagonalMajor { get; set; }
        public double DiagonalMinor { get; set; }
        public double Side { get; set; }

        public Rhombus(double diagonalMajor, double diagonalMinor, double side)
        {
            DiagonalMajor = diagonalMajor;
            DiagonalMinor = diagonalMinor;
            Side = side;
        }

        public override double CalculateArea()
        {
            return (DiagonalMajor * DiagonalMinor) / 2;
        }

        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }

        public override bool IsValid()
        {
            return DiagonalMajor > 0 && DiagonalMinor > 0 && Side > 0;
        }
    }
}
