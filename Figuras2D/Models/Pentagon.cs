using System;

namespace Figuras2D.Models
{
    public class Pentagon : Shapes
    {
        public double Lado { get; set; }

        public Pentagon(double lado)
        {
            Lado = lado;
        }

        public override double CalculateArea()
        {
            return (Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) / 4) * Lado * Lado;
        }

        public override double CalculatePerimeter()
        {
            return 5 * Lado;
        }

        public override bool IsValid()
        {
            return Lado > 0;
        }
    }
}