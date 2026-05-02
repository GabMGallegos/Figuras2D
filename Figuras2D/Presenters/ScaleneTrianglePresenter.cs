using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Figuras2D.Models;

namespace Figuras2D.Presenters
{
    public class ScaleneTrianglePresenter
    {
        private readonly ScaleneTriangle _scaleneTriangle;

        public ScaleneTrianglePresenter(ScaleneTriangle scaleneTriangle)
        {
            _scaleneTriangle = scaleneTriangle;
        }

        public double Area => _scaleneTriangle.CalculateArea();
        public double Perimeter => _scaleneTriangle.CalculatePerimeter();
        public bool IsValid => _scaleneTriangle.IsValid();
    }
}