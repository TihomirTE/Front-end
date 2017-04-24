using GameFifteen.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTests
{

    [TestFixture]
    public class CellTests
    {
        [Test]
        public void AddCorrectParameters_ConstructorShouldReturnCellReference()
        {
            // Arrange & Act
            int x = 2;
            int y = 2;
            var cell = new Cell(x, y);

            // Assert
            Assert.IsInstanceOf<Cell>(cell);
        }

        [Test]
        public void OperatorSum_ShouldIncreaseProperlyTheValueOfThoCells()
        {
            // Arrange
            var currentCell = new Cell(2, 3);
            var nextCell = new Cell(3, 4);

            // Act & Assert
            Assert.AreEqual(5, currentCell.X + nextCell.X);
            Assert.AreEqual(7, currentCell.Y + nextCell.Y);
        }


    }
}
