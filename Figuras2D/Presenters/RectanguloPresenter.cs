using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class RectanguloPresenter
    {
        private readonly Rectangulo _rectangulo;

        public RectanguloPresenter(Rectangulo rectangulo)
        {
            _rectangulo = rectangulo;
        }

        public double Area => _rectangulo.CalculateArea();

        public double Perimeter => _rectangulo.CalculatePerimeter();

        public bool IsValid => _rectangulo.IsValid();
    }
}