using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareLibrary;
using SquareLibrary.Figures;
using Xunit;

namespace SquareLibraryTests.FiguresTests
{
    public class TriangleTests
    {
        [Fact]
        public void AreaTests()
        {
            double ab = 3;
            double bc = 2;
            double ac = 4;

            var arr = new[] {ab, bc, ac};
            
            Triangle triangle;
            try {
                triangle = new Triangle(ab, bc, ac);
            }
            catch (NegativeValueException) {
                Assert.Contains(arr, y => y <= 0);
                return;
            }

            // Проверяем 4 знака после запятой
            var result = Math.Round(triangle.Area(), 4);
            var expected = 2.9047;
            Assert.Equal(result, expected);
        }

        [Fact]
        public void IsRightTests()
        {
            double ab = -2;
            double bc = 4;
            double ac = 5;

            var arr = new[] { ab, bc, ac };

            Triangle triangle;
            try {
                triangle = new Triangle(ab, bc, ac);
            }
            catch (NegativeValueException) {
                Assert.Contains(arr, y => y <= 0);
                return;
            }

            // Проверяем 4 знака после запятой
            var result = triangle.IsRight;
            var expected = true;
            Assert.Equal(result, expected);
        }
    }
}
