using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareLibrary.Figures
{
    public class Triangle : Figure
    {
        private double _ab;
        public double AB {
            get => _ab;
            set {
                if (value <= 0)
                    throw new NegativeValueException();

                _ab = value;
            }
        }

        private double _bc;
        public double BC {
            get => _bc;
            set {
                if (value <= 0)
                    throw new NegativeValueException();

                _bc = value;
            }
        }

        private double _ac;
        public double AC {
            get => _ac;
            set {
                if (value <= 0)
                    throw new NegativeValueException();

                _ac = value;
            }
        }

        private double[] _smallSides {
            get {
                var sides = new[] { AB, BC, AC };
                return sides.Where(y => y != _bigSide).ToArray();
            }
        }

        private double _bigSide {
            get {
                var sides = new[] { AB, BC, AC };
                var max = sides.Max();
                return sides.SingleOrDefault(y => y == max);
            }
        }

        public bool IsRight {
            get {
                var bigSide = _bigSide;
                return bigSide != 0 && Math.Pow(bigSide, 2) == _smallSides.Sum(y => Math.Pow(y, 2));
            }
        }

        public Triangle(double ab, double bc, double ac) : base(nameof(Triangle))
        {
            AB = ab;
            BC = bc;
            AC = ac;
        }

        public override double Area()
        {
            if(IsRight)
                return _smallSides.Aggregate<double, double>(1, (current, s) => current * s);
            
            var p = (AB + BC + AC) / 2;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
        }
    }
}
