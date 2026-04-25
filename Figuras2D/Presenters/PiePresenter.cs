using Figuras2D.Models;

namespace _2d_shape.Presenters
{
    public class PiePresenter
    {
        private readonly Pie _pie;

        public PiePresenter(Pie pie)
        {
            _pie = pie;
        }

        public double Area => _pie.CalculateArea();

        public double Perimeter => _pie.CalculatePerimeter();

        public bool IsValid => _pie.IsValid();
    }
}