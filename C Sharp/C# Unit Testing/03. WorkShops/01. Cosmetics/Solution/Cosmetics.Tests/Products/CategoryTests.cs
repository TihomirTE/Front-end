using Cosmetics.Contracts;
using Cosmetics.Products;
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
    public class CategoryTests
    {
        [Test]
        public void AddCosmetics_ShouldAddProductToTheProductList()
        {
            // Arrange
            var category = new MockedCategory("ForCats");
            var product = new Mock<IProduct>();

            // Act
            category.AddProduct(product.Object);

            // Assert
            Assert.IsTrue(category.Products.Contains(product.Object));
        }

        [Test]
        public void RemoveCosmetics_ShouldRemoveProductFromTheProductList()
        {
            // Arrange
            var category = new MockedCategory("ForCats");
            var product = new Mock<IProduct>();
            category.Products.Add(product.Object);

            // Act
            category.RemoveProduct(product.Object);

            // Assert
            Assert.IsFalse(category.Products.Contains(product.Object));
        }



        [Test]
        public void CategoryPrint_ShouldReturnCategoryDetailsInTheRequiredFormat()
        {
            var category = new Category("ForAnimals");

            // Act
            var result = category.Print();

            // Assert
            Assert.AreEqual("ForAnimals category - 0 products in total", result);
        }
    }
}
