using System;

namespace Figuras2D.Models
{
    public class Elipse : Shapes
    {
        public double SemiejeMayor { get; set; }
        public double SemiejeMenor { get; set; }

        public Elipse(double semiejeMayor, double semiejeMenor)
        {
            SemiejeMayor = semiejeMayor;
            SemiejeMenor = semiejeMenor;
        }

        public override double CalculateArea()
        {
            return Math.PI * SemiejeMayor * SemiejeMenor;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * (3 * (SemiejeMayor + SemiejeMenor) -
                   Math.Sqrt((3 * SemiejeMayor + SemiejeMenor) *
                   (SemiejeMayor + 3 * SemiejeMenor)));
        }

        public override bool IsValid()
        {
            return SemiejeMayor > 0 && SemiejeMenor > 0;
        }
    }
}