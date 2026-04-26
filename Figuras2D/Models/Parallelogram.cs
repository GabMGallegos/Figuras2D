using System;

namespace Figuras2D.Models
{
    public class Parallelogram : Shapes
    {
        public double Base { get; set; }
        public double Lado { get; set; }
        public double Angulo { get; set; } 

        public Parallelogram(double base_, double lado, double angulo)
        {
            Base = base_;
            Lado = lado;
            Angulo = angulo;
        }

        public override double CalculateArea()
        {
            return Base * Lado * Math.Sin(Angulo * Math.PI / 180);
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Base + Lado);
        }

        public override bool IsValid()
        {
            return Base > 0 && Lado > 0 && Angulo > 0 && Angulo < 180;
        }
    }
}