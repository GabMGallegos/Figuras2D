using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class TrianglePresenter
    {
        private readonly Triangle _triangle;

        public TrianglePresenter(Triangle triangle)
        {
            _triangle = triangle;
        }

        public double Area => _triangle.CalculateArea();
        public double Perimeter => _triangle.CalculatePerimeter();
        public bool IsValid => _triangle.IsValid();
    }
}