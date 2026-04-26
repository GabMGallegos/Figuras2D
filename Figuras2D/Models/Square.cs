using System.Drawing;

namespace Figuras2D.Models
{
    public class Square : Shapes
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double CalculateArea()
        {
            return Side * Side;
        }

        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }

        public override bool IsValid()
        {
            return Side > 0;
        }

        public PointF[] GetDrawingPoints(float scale = 1.0f)
        {
            float halfSide = (float)(Side * scale) / 2;

            return new PointF[]
            {
                new PointF(-halfSide, -halfSide),
                new PointF( halfSide, -halfSide),
                new PointF( halfSide,  halfSide),
                new PointF(-halfSide,  halfSide)
            };
        }
    }
}