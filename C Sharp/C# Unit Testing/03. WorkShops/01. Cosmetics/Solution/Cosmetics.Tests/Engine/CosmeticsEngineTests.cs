using Cosmetics.Contracts;
using Cosmetics.Tests.Engine.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenTheInputIsInFormatInCreateCategoryCommand_ShouldReadParseAndExecuteCreateCategoryCommand()
        {
            // Arrange
            var categoryName = "ForAnimals";

            var stubFactory = new Mock<ICosmeticsFactory>();
            var stubShoppingCart = new Mock<IShoppingCart>();
            var stubCommandParser = new Mock<ICommandParser>();

            var stubCommand = new Mock<ICommand>();
            var stubCategory = new Mock<ICategory>();

            // setup stubCommand
            stubCommand.SetupGet(p => p.Name).Returns("CreateCategory");
            stubCommand.SetupGet(p => p.Parameters).Returns(() => new List<string>() { categoryName });
            // setup stubCommandParser
            stubCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { stubCommand.Object });

            // expected result
            stubCategory.SetupGet(c => c.Name).Returns(categoryName);

            stubFactory.Setup(c => c.CreateCategory(categoryName)).Returns(stubCategory.Object);

            var mockEngine = new MockedCosmeticEngine(stubFactory.Object, stubShoppingCart.Object, stubCommandParser.Object);

            // Act
            mockEngine.Start();

            // Assert
            Assert.IsTrue(mockEngine.Categories.ContainsKey(categoryName));
            Assert.AreSame(stubCategory.Object, mockEngine.Categories[categoryName]);

        }

        [Test]
        public void Start_WhenTheInputIsInFormatInAddToCategoryCommand_ShouldReadParseAndExecuteAddToCategoryCommand()
        {
            // Arrange
            var categoryName = "ForEveryDay";
            var productName = "super";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedToothpatse = new Mock<IToothpaste>();

            mockedCommand.SetupGet(n => n.Name).Returns("AddToCategory");
            mockedCommand.SetupGet(p => p.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var mockedEngine = new MockedCosmeticEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            mockedEngine.Categories.Add(categoryName, mockedCategory.Object);
            mockedEngine.Products.Add(productName, mockedToothpatse.Object);
            
            // Act
            mockedEngine.Start();

            // Assert
            mockedCategory.Verify(c => c.AddProduct(mockedToothpatse.Object), Times.Once);

        }
    }
}
