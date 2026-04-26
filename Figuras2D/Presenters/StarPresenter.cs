using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class StarPresenter
    {
        private readonly Star _star;

        public StarPresenter(Star star)
        {
            _star = star;
        }

        public double Area => _star.CalculateArea();

        public double Perimeter => _star.CalculatePerimeter();

        public bool IsValid => _star.IsValid();
    }
}