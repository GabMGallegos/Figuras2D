using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class HexagonPresenter
    {
        private readonly Hexagon _hexagon;

        public HexagonPresenter(Hexagon hexagon)
        {
            _hexagon = hexagon;
        }

        public double Area => _hexagon.CalculateArea();
        public double Perimeter => _hexagon.CalculatePerimeter();
        public bool IsValid => _hexagon.IsValid();
    }
}