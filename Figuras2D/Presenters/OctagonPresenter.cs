using Figuras2D.Models;

namespace _2d_shape.Presenters
{
    public class OctagonPresenter
    {
        private readonly Octagon _octagon;

        public OctagonPresenter(Octagon octagon)
        {
            _octagon = octagon;
        }

        public double Area => _octagon.CalculateArea();

        public double Perimeter => _octagon.CalculatePerimeter();

        public bool IsValid => _octagon.IsValid();
    }
}