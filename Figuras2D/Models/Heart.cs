using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras2D.Models
{
    public class Heart : Shapes
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Heart(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            double radius = Width / 4;
            double circlesArea = Math.PI * Math.Pow(radius, 2);
            double triangleArea = (Width * (Height / 2)) / 2;

            return circlesArea + triangleArea;
        }

        public override double CalculatePerimeter()
        {
            double radius = Width / 4;
            double upperCurves = 2 * Math.PI * radius;
            double sideLength = Math.Sqrt(Math.Pow(Width / 2, 2) + Math.Pow(Height / 2, 2));

            return upperCurves + (2 * sideLength);
        }

        public override bool IsValid()
        {
            return Width > 0 && Height > 0;
        }
    }
}
