using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class Kite : Shapes
    {
        public double DiagonalMajor { get; set; }
        public double DiagonalMinor { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Kite(double diagonalMajor, double diagonalMinor, double sideA, double sideB)
        {
            DiagonalMajor = diagonalMajor;
            DiagonalMinor = diagonalMinor;
            SideA = sideA;
            SideB = sideB;
        }

        public override double CalculateArea()
        {
            return (DiagonalMajor * DiagonalMinor) / 2;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (SideA + SideB);
        }

        public override bool IsValid()
        {
            return DiagonalMajor > 0 && DiagonalMinor > 0 && SideA > 0 && SideB > 0;
        }
    }
}
