using System;

namespace Figuras2D.Models
{
    public class Star : Shapes
    {
        public double RadioExterno { get; set; }
        public double RadioInterno { get; set; }
        public int Puntas { get; set; }

        public Star(double radioExterno, double radioInterno, int puntas = 5)
        {
            RadioExterno = radioExterno;
            RadioInterno = radioInterno;
            Puntas = puntas;
        }

        public override double CalculateArea()
        {
            double angulo = Math.PI / Puntas;
            double areaExterno = (Puntas * RadioExterno * RadioExterno * Math.Sin(2 * angulo)) / 2;
            double areaInterno = (Puntas * RadioInterno * RadioInterno * Math.Sin(2 * angulo)) / 2;
            return areaExterno - areaInterno;
        }

        public override double CalculatePerimeter()
        {
            double angulo = Math.PI / Puntas;
            double lado = Math.Sqrt(
                RadioExterno * RadioExterno +
                RadioInterno * RadioInterno -
                2 * RadioExterno * RadioInterno * Math.Cos(angulo)
            );
            return 2 * Puntas * lado;
        }

        public override bool IsValid()
        {
            return RadioExterno > 0 && RadioInterno > 0 &&
                   RadioInterno < RadioExterno && Puntas >= 3;
        }
    }
}