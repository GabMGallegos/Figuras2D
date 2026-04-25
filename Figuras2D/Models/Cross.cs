using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class Cross : Shapes
    {
        public double ArmLength { get; set; }
        public double Thickness { get; set; }

        public Cross(double armLength, double thickness)
        {
            ArmLength = armLength;
            Thickness = thickness;
        }

        public override double CalculateArea()
        {
            return (2 * ArmLength * Thickness) - (Thickness * Thickness);
        }

        public override double CalculatePerimeter()
        {
            return 4 * ArmLength;
        }

        public override bool IsValid()
        {
            return ArmLength > 0 && Thickness > 0 && Thickness < ArmLength;
        }
    }
}