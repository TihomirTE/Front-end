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

        [Test]
        public void RemoveProduct_ShouldRemoveThePassedProductToTheProductLis()
        {
            // Arrange
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();
            mockedShoppingCart.Products.Add(mockedProduct.Object);

            // Act
            mockedShoppingCart.RemoveProduct(mockedProduct.Object);

            // Assert
            Assert.AreEqual(false, mockedShoppingCart.Products.Contains(mockedProduct.Object));
        }


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
        public void TotalPrice_ShouldReturnTotalSumOfAllProducts()
        {
            // Arrange
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct1 = new Mock<IProduct>();
            var mockedProduct2 = new Mock<IProduct>();

            mockedProduct1.SetupGet(p => p.Price).Returns(1);
            mockedProduct2.SetupGet(p => p.Price).Returns(2);

            mockedShoppingCart.Products.Add(mockedProduct1.Object);
            mockedShoppingCart.Products.Add(mockedProduct2.Object);

            // Act & Assert
            Assert.AreEqual(3, mockedShoppingCart.TotalPrice());
        }

        [Test]
        public void TotalPrice_IfThereAreNoProducts_ShouldReturnZero()
        {
            // Arrange
            var mockedShoppingCart = new MockedShoppingCart();

            // Act
            var result = mockedShoppingCart.TotalPrice();

            // Assert
            Assert.Zero(result);
        }


    }
}
