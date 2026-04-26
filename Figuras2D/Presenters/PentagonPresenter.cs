using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class PentagonPresenter
    {
        private readonly Pentagon _pentagon;

        public PentagonPresenter(Pentagon pentagon)
        {
            _pentagon = pentagon;
        }

        public double Area => _pentagon.CalculateArea();

        public double Perimeter => _pentagon.CalculatePerimeter();

        public bool IsValid => _pentagon.IsValid();
    }
}