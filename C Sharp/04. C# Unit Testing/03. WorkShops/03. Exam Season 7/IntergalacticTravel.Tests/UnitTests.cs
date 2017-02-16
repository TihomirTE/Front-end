using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_ShouldThrowNullReferenceException_IfTheObjectIsnull()
        {
            // Arrange
            var unit = new Unit(43, "Pesho");

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));

        }

        [Test]
        public void Pay_ShouldDecreaseTheAmountOfResources()
        {
            // Arrange
            var unit = new Unit(43, "Pesho");

            var mockedResources = new Mock<IResources>();
            var initialGold = mockedResources.Setup(x => x.GoldCoins).Returns(50);
            var initialSilver = mockedResources.Setup(x => x.SilverCoins).Returns(100);
            var initialBronze = mockedResources.Setup(x => x.BronzeCoins).Returns(200);

            unit.Resources.Add(mockedResources.Object);
            unit.Resources.Add(mockedResources.Object);

            var resultGold = unit.Resources.GoldCoins - mockedResources.Object.GoldCoins;
            var resultSilver = unit.Resources.SilverCoins - mockedResources.Object.SilverCoins;
            var resultBronze = unit.Resources.BronzeCoins - mockedResources.Object.BronzeCoins;

            // Act
            unit.Pay(mockedResources.Object);
            var actualGoldCoins = unit.Resources.GoldCoins;
            var actualSilverCoins = unit.Resources.SilverCoins;
            var actualBronzeCoins = unit.Resources.BronzeCoins;

            // Assert
            Assert.AreEqual(resultGold, actualGoldCoins);
            Assert.AreEqual(resultSilver, actualSilverCoins);
            Assert.AreEqual(resultBronze, actualBronzeCoins);
        }

        [Test]
        public void Pay_ShouldReturnResourceObject()
        {
            // Arrange
            var unit = new Unit(43, "Pesho");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(50);
            mockedResources.Setup(x => x.SilverCoins).Returns(100);
            mockedResources.Setup(x => x.BronzeCoins).Returns(200);

            var expectedtGold = mockedResources.Object.GoldCoins;
            var expectedSilver = mockedResources.Object.SilverCoins;
            var expectedBronze = mockedResources.Object.BronzeCoins;

            // Act
            var actual = unit.Pay(mockedResources.Object);

            // Assert
            Assert.AreEqual(expectedtGold, actual.GoldCoins);
            Assert.AreEqual(expectedSilver, actual.SilverCoins);
            Assert.AreEqual(expectedBronze, actual.BronzeCoins);
        }
    }
}
