using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interwiew.Figures
{
    class Rectangle : IFigure
    {
        private double _width;
        private double _height;

        public Rectangle (double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double Area()
        {
            return _width * _height;
        }
    }
}
