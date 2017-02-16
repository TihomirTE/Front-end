using IntergalacticTravel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourceFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_ShouldReturnNewlyCreatedResources(string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act
            var result = resourceFactory.GetResources(command);

            // Assert
            Assert.IsInstanceOf<Resources>(result);
        }

        [TestCase("create resources x y z")]
        [TestCase("create resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_WhenTheInputIsInvalidCommand_ShouldThrowInvalidOperationException(string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act
            var result = Assert.Throws<InvalidOperationException>(() => resourceFactory.GetResources(command));
            var message = result.Message;

            // Assert
            StringAssert.Contains("command", message);
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ShouldThrowOverFlowException_WhenTheResourceAmountIsLargerThanUIntMaxValue(string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(() => resourceFactory.GetResources(command));
        }
    }
}
