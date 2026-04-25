using Figuras2D.Models;

namespace _2d_shape.Presenters
{
    public class KitePresenter
    {
        private readonly Kite _kite;

        public KitePresenter(Kite kite)
        {
            _kite = kite;
        }

        public double Area => _kite.CalculateArea();

        public double Perimeter => _kite.CalculatePerimeter();

        public bool IsValid => _kite.IsValid();
    }
}