using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class Semicircle : Shapes
    {
        public double Radius { get; set; }

        public Semicircle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return (Math.PI * Math.Pow(Radius, 2)) / 2;
        }

        public override double CalculatePerimeter()
        {
            return (Math.PI * Radius) + (2 * Radius);
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }
    }
}
