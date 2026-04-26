using Figuras2D.Models;
using System.Drawing;

namespace Figuras2D.Presenters
{
    public class SquarePresenter
    {
        private readonly Square _square;

        public SquarePresenter(Square square)
        {
            _square = square;
        }

        public double Area => _square.CalculateArea();
        public double Perimeter => _square.CalculatePerimeter();
        public bool IsValid => _square.IsValid();

        public PointF[] GetDrawingPoints(float scale = 1.0f)
        {
            return _square.GetDrawingPoints(scale);
        }

        public double Side
        {
            get => _square.Side;
            set => _square.Side = value;
        }
    }
}
