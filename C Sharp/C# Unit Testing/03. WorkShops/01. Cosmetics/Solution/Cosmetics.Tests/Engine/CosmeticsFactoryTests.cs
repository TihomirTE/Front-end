using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampo_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateShampoo(name, "Head", 10, GenderType.Men, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampo_WhenLengthNameIsOutOfRange_ShouldThrowIndexOutOfRange()
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateShampoo("TooLongNameForShampoo", "Head", 10, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampo_WhenBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateShampoo("Shampooo", brand, 10, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("b")]
        [TestCase("TooLongBrandName")]
        public void CreateShampo_WhenLengthBrandIsOutOfRange_ShouldThrowIndexOutOfRange(string brand)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateShampoo("Shampooo", brand, 10, GenderType.Men, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampo_WhenParametersAreValid_ShouldReturnNewShampoo()
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Act
            var shampoo = cosmeticsFactory.CreateShampoo("Shampoo", "Head", 10, GenderType.Men, 100, UsageType.EveryDay);

            // Arrange
            Assert.IsInstanceOf<IShampoo>(shampoo);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new Category(name));
        }

        [TestCase("b")]
        [TestCase("TooLongCategoryName")]
        public void CreateCategory_WhenLengthNameIsOutOfRange_ShouldThrowIndexOutOfRange(string name)
        {
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => new Category(name));
        }

        [Test]
        public void CreateCategory_WhenParametersAreValid_ShouldReturnNewCategory()
        {
            // Arrange
            var name = "category";

            // Act
            var category = new Category(name);

            // Arrange
            Assert.IsInstanceOf<ICategory>(category);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();
            var ingredients = new List<string> { "something", "somethingelse" };
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateToothpaste(name, "Head", 10, GenderType.Men, ingredients));
        }

        [TestCase("fo")]
        [TestCase("tooLongToothpasteName")]
        public void CreateToothpaste_WhenNameIsOutOfRange_ShouldThrowIndexOutOfRangeException(string name)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();
            var ingredients = new List<string> { "something", "somethingelse" };
            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateToothpaste(name, "Head", 10, GenderType.Men, ingredients));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();
            var ingredients = new List<string> { "something", "somethingelse" };
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateToothpaste("Tooth", brand, 10, GenderType.Men, ingredients));
        }

        [TestCase("f")]
        [TestCase("tooLongToothpasteName")]
        public void CreateToothpaste_WhenBrandIsOutOfRange_ShouldThrowIndexOutOfRangeException(string brand)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();
            var ingredients = new List<string> { "something", "somethingelse" };
            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateToothpaste("Tooth", brand, 10, GenderType.Men, ingredients));
        }

        [TestCase("sol", "chushki")]
        [TestCase("zahar","tooLongIngredientsName")]
        public void CreateToothpaste_WhenIngredientsAreOutOfRange_ShouldThrowIndexOutOfRangeException(params string[] ingredients)
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();
            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateToothpaste("Tooth", "cool", 10, GenderType.Men, ingredients));
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnNewShoppingCart()
        {
            // Arrange
            var cosmeticsFactory = new CosmeticsFactory();

            // Act
            var shoppingCart = cosmeticsFactory.CreateShoppingCart();

            // Act & Assert
            Assert.IsInstanceOf<IShoppingCart>(shoppingCart);
        }

    }
}
