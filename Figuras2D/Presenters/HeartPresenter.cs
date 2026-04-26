using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class HeartPresenter
    {
        private readonly Heart _heart;

        public HeartPresenter(Heart heart)
        {
            _heart = heart;
        }

        public double Area => _heart.CalculateArea();

        public double Perimeter => _heart.CalculatePerimeter();

        public bool IsValid => _heart.IsValid();
    }
}