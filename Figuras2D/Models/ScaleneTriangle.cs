using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class ScaleneTriangle : Shapes
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public ScaleneTriangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Calcula el área usando la fórmula de Herón.
        /// </summary>
        public override double CalculateArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        /// <summary>
        /// Calcula el perímetro sumando los tres lados.
        /// </summary>
        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        /// <summary>
        /// Valida que:
        /// - Los tres lados sean positivos.
        /// - Se cumpla la desigualdad triangular.
        /// - Los tres lados sean distintos (condición de escaleno).
        /// </summary>
        public override bool IsValid()
        {
            bool sidesPositive = SideA > 0 && SideB > 0 && SideC > 0;
            bool triangleInequality = SideA + SideB > SideC &&
                                      SideA + SideC > SideB &&
                                      SideB + SideC > SideA;
            bool isScalene = SideA != SideB && SideB != SideC && SideA != SideC;

            return sidesPositive && triangleInequality && isScalene;
        }
    }
}