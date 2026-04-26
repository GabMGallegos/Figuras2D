using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class ParallelogramPresenter
    {
        private readonly Parallelogram _parallelogram;

        public ParallelogramPresenter(Parallelogram parallelogram)
        {
            _parallelogram = parallelogram;
        }

        public double Area => _parallelogram.CalculateArea();

        public double Perimeter => _parallelogram.CalculatePerimeter();

        public bool IsValid => _parallelogram.IsValid();
    }
}