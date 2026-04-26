using System;
using System.Drawing;

namespace Figuras2D.Models
{
    public class Circle : Shapes
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }

        public PointF[] GetDrawingPoints(float scale = 1.0f)
        {
            float scaledRadius = (float)(Radius * scale);
            int segments = 100;
            PointF[] points = new PointF[segments + 1];

            for (int i = 0; i <= segments; i++)
            {
                double angle = 2 * Math.PI * i / segments;
                float x = scaledRadius * (float)Math.Cos(angle);
                float y = scaledRadius * (float)Math.Sin(angle);
                points[i] = new PointF(x, y);
            }

            return points;
        }
    }
}