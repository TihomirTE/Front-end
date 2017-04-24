using NUnit.Framework;
using RotatingWalkInMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTests.ModelsTests
{
    [TestFixture]
    public class WalkInMatrixTests
    {
        [Test]
        public void Contructor_ShouldThrowArgumentException_WhenTheInputIsNotAConvertableToNumber()
        {
            // Arrange
            var input = "string";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new WalkInMatrix(input));
        }

        [TestCase("0")]
        [TestCase("101")]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenTheSizeIsNotInRange(string size)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new WalkInMatrix(size));
        }

        [Test]
        public void Constructor_ShouldMakeInstanceOfWalkInMartixType_WhenTheInputIsCorrect()
        {
            // Arrange & Act
            var input = "10";
            var matrix = new WalkInMatrix(input);

            // Assert
            Assert.IsInstanceOf<WalkInMatrix>(matrix);
        }
    }
}
