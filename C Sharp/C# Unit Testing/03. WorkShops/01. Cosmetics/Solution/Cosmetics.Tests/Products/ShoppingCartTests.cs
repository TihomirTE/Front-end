using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Tests.Products.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void ContainProduct_ShouldReturnTrueIfThePassedProductToThetLis()
        {
            // Arrange
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            // Act
            mockedShoppingCart.Products.Add(mockedProduct.Object);

            // Assert
            Assert.IsTrue(mockedShoppingCart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void AddProduct_ShouldAddThePassedProductToTheProductLis()
        {
            // Arrange
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            // Act
            mockedShoppingCart.AddProduct(mockedProduct.Object);

            // Assert
            Assert.IsTrue(mockedShoppingCart.Products.Contains(mockedProduct.Object));
        }
    }
}
