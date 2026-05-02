using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class CrescentMoonPresenter
    {
        private readonly CrescentMoon _crescentMoon;

        public CrescentMoonPresenter(CrescentMoon crescentMoon)
        {
            _crescentMoon = crescentMoon;
        }

        public double Area => _crescentMoon.CalculateArea();
        public double Perimeter => _crescentMoon.CalculatePerimeter();
        public bool IsValid => _crescentMoon.IsValid();

        public double InnerRadius => _crescentMoon.InnerRadius;

        public double Offset => _crescentMoon.Offset;
    }
}