using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class CrossPresenter
    {
        private readonly Cross _cross;

        public CrossPresenter(Cross cross)
        {
            _cross = cross;
        }

        public double Area => _cross.CalculateArea();

        public double Perimeter => _cross.CalculatePerimeter();

        public bool IsValid => _cross.IsValid();
    }
}
