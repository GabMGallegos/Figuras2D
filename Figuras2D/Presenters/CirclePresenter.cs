using Figuras2D.Models;
using System.Drawing;

namespace Figuras2D.Presenters
{
    public class CirclePresenter
    {
        private readonly Circle _circle;

        public CirclePresenter(Circle circle)
        {
            _circle = circle;
        }

        public double Area => _circle.CalculateArea();
        public double Perimeter => _circle.CalculatePerimeter();
        public bool IsValid => _circle.IsValid();

        public PointF[] GetDrawingPoints(float scale = 1.0f)
        {
            return _circle.GetDrawingPoints(scale);
        }

        public double Radius
        {
            get => _circle.Radius;
            set => _circle.Radius = value;
        }
    }
}