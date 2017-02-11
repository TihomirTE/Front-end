using NUnit.Framework;
using SantaseGame;
using SantaseGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanataseGame.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        [TestCase(7)]
        public void GetNextCard_ShouldNotReturnNull()
        {
            // Arrange
            Deck deck = new Deck();

            // Act & Assert
            Assert.IsNotNull(deck.GetNextCard());
        }
    }
}
