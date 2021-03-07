using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainProjectTests
{
    [TestClass]
    public class ReverseNumberTests
    {
        [TestMethod]
        public void Reverse105_501returned()
        {
            // arrange
            var input = 105;
            var expected = 501;

            // act
            var actual = TrainProject.Program.ReverseNumber(input);

            // assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
