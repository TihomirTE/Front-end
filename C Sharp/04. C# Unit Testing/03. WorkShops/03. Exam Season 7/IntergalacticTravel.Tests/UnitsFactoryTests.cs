using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_ShouldReturnNewProcyon_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Procyon Gosho 1";
            var unitFactory = new UnitsFactory();

            // Act
            var result = unitFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Procyon>(result);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLuyten_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Luyten Pesho 2";
            var unitFactory = new UnitsFactory();

            // Act
            var result = unitFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Luyten>(result);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLacaille_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Lacaille Tosho 3";
            var unitFactory = new UnitsFactory();

            // Act
            var result = unitFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Lacaille>(result);
        }

        [TestCase("create unit Unknown  Tosho 3")]
        [TestCase("create unit Tosho 3")]
        public void GetUnit_ShouldReturnNewLacaille_WhenValidCommandIsPassed(string command)
        {
            // Arrange
            var unitFactory = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));
        }
    }
}
