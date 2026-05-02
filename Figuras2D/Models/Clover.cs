using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Figuras2D.Models
{
    public class Clover : Shapes
    {
        public double Radius { get; set; }

        public Clover(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return (Math.PI / 2.0 - Math.Sqrt(3) + 3.0) * Radius * Radius;
        }

 
        public override double CalculatePerimeter()
        {
            return 4 * Math.PI * Radius;
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }
    }
}