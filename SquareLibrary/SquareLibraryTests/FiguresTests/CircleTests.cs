using SquareLibrary;
using SquareLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SquareLibraryTests.FiguresTests
{
    public class CircleTests
    {
        [Fact]
        public void AreaTest()
        {
            double radius = 3;
            Circle circle;
            try {
                circle = new Circle(radius);
            } catch (NegativeValueException) {
                Assert.True(radius <= 0);
                return;
            }

            var result = Math.Round(circle.Area(), 2);
            var expected = 28.27;
            Assert.Equal(result, expected);
        }
    }
}
