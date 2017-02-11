using Cosmetics.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenInputIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(input));
        }

        [Test]
        public void Parse_WhenInputThatRepresentsCommandNameIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Arrange
            string input = "";

            // Act & Assert
            Assert.That(() => Command.Parse(input), Throws.ArgumentNullException.With.Message.Contain("Name"));
        }

        [Test]
        public void Parse_WhenInputThatRepresentsCommandParameterIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Arrange
            string input = "words ";

            // Act & Assert
            Assert.That(() => Command.Parse(input), Throws.ArgumentNullException.With.Message.Contain("List"));
        }

        [Test]
        public void Parse_WhenInputIsInValidFormat_ShouldReturnNewCommand()
        {
            // Arrange
            string input = "valid String";

            // Act 
            var result = Command.Parse(input);

            // Assert
            Assert.IsInstanceOf<Command>(result);
        }

        [Test]
        public void Parse_WhenInputIsInValidFormat_ShouldSetCorrectNameProperty()
        {
            // Arrange
            string input = "valid string";
            string expectedResult = "valid";

            // Act
            var currentResult = Command.Parse(input).Name;

            // Assert
            Assert.AreEqual(expectedResult, currentResult);
        }

        [Test]
        public void Parse_WhenInputIsInValidFormat_ShouldSetCorrectParameterProperty()
        {
            // Arrange
            string input = "valid string property";
            var expectedResult = new List<string> { "string", "property" };

            // Act
            var currentResult = Command.Parse(input).Parameters;

            // Assert
            Assert.AreEqual(expectedResult, currentResult);
        }
    }
}
