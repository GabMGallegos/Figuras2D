using System;

namespace Figuras2D.Models
{
    public class Rectangulo : Shapes
    {
        public double Ancho { get; set; }
        public double Alto { get; set; }

        public Rectangulo(double ancho, double alto)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public override double CalculateArea()
        {
            return Ancho * Alto;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Ancho + Alto);
        }

        public override bool IsValid()
        {
            return Ancho > 0 && Alto > 0;
        }
    }
}