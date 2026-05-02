using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Figuras2D.Models
{




    public class Trapezoid : Shapes
    {
        public double MajorBase { get; set; }
        public double MinorBase { get; set; }
        public double Height { get; set; }

        public Trapezoid(double majorBase, double minorBase, double height)
        {
            MajorBase = majorBase;
            MinorBase = minorBase;
            Height = height;
        }

        /// <summary>
        /// Longitud del lado lateral (trapecio isósceles).
        /// LateralSide = sqrt(height² + ((majorBase - minorBase) / 2)²)
        /// </summary>
        public double LateralSide =>
            Math.Sqrt(Height * Height + Math.Pow((MajorBase - MinorBase) / 2, 2));

        /// <summary>
        /// Área = ((base mayor + base menor) / 2) × altura
        /// </summary>
        public override double CalculateArea()
        {
            return ((MajorBase + MinorBase) / 2) * Height;
        }

        /// <summary>
        /// Perímetro = base mayor + base menor + 2 × lado lateral
        /// </summary>
        public override double CalculatePerimeter()
        {
            return MajorBase + MinorBase + 2 * LateralSide;
        }

        /// <summary>
        /// Valida que todas las medidas sean positivas y que la base mayor sea
        /// estrictamente mayor que la base menor.
        /// </summary>
        public override bool IsValid()
        {
            return MajorBase > 0 &&
                   MinorBase > 0 &&
                   Height > 0 &&
                   MajorBase > MinorBase;
        }
    }
}