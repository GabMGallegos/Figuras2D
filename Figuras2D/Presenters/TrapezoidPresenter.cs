using Figuras2D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class TrapezoidPresenter
    {
        private readonly Trapezoid _trapezoid;

        public TrapezoidPresenter(Trapezoid trapezoid)
        {
            _trapezoid = trapezoid;
        }

        public double Area => _trapezoid.CalculateArea();
        public double Perimeter => _trapezoid.CalculatePerimeter();
        public bool IsValid => _trapezoid.IsValid();

        public double LateralSide => _trapezoid.LateralSide;
    }
}