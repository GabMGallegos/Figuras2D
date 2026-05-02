using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Figuras2D.Models
{
    public class Hexagon : Shapes
    {
        public double Side { get; set; }

        public Hexagon(double side)
        {
            Side = side;
        }

        public override double CalculateArea()
        {
            return (3 * Math.Sqrt(3) / 2) * Side * Side;
        }

        public override double CalculatePerimeter()
        {
            return 6 * Side;
        }

        public override bool IsValid()
        {
            return Side > 0;
        }
    }
}