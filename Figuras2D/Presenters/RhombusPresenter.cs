using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class RhombusPresenter
    {
        private readonly Rhombus _rhombus;

        public RhombusPresenter(Rhombus rhombus)
        {
            _rhombus = rhombus;
        }

        public double Area => _rhombus.CalculateArea();

        public double Perimeter => _rhombus.CalculatePerimeter();

        public bool IsValid => _rhombus.IsValid();
    }
}