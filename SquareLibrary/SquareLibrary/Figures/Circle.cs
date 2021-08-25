using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareLibrary.Figures
{
    public class Circle : Figure
    {
        private double _radius;
        public double Radius {
            get => _radius;
            set {
                if(value <= 0 )
                    throw new NegativeValueException();

                _radius = value;
            }
        }

        public Circle(double radius) : base(nameof(Circle))
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
