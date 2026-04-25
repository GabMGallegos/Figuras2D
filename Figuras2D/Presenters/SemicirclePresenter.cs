using Figuras2D.Models;

namespace _2d_shape.Presenters
{
    public class SemicirclePresenter
    {
        private readonly Semicircle _semicircle;

        public SemicirclePresenter(Semicircle semicircle)
        {
            _semicircle = semicircle;
        }

        public double Area => _semicircle.CalculateArea();

        public double Perimeter => _semicircle.CalculatePerimeter();

        public bool IsValid => _semicircle.IsValid();
    }
}