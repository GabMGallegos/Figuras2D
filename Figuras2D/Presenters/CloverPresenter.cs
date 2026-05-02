using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class CloverPresenter
    {
        private readonly Clover _clover;

        public CloverPresenter(Clover clover)
        {
            _clover = clover;
        }

        public double Area => _clover.CalculateArea();
        public double Perimeter => _clover.CalculatePerimeter();
        public bool IsValid => _clover.IsValid();
    }
}