using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class ElipsePresenter
    {
        private readonly Elipse _elipse;

        public ElipsePresenter(Elipse elipse)
        {
            _elipse = elipse;
        }

        public double Area => _elipse.CalculateArea();

        public double Perimeter => _elipse.CalculatePerimeter();

        public bool IsValid => _elipse.IsValid();
    }
}