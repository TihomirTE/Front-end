using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Core;
using SchoolSystem.Core.Contracts;

namespace SchoolSystem.Tests.Core
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenReaderIsNotProvided()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writer.Object, parser.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenWriterIsNotProvided()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var parser = new Mock<IParser>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, null, parser.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParserIsNotProvided()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, writer.Object, null));
        }

        [Test, Timeout(3000)]
        public void Start_ShouldNotFallIntoInfiniteLoop_WhenPassedValidTerminationCommand()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            // Act
            var terminationCommand = "End";
            reader.Setup(c => c.ReadLine()).Returns(terminationCommand);

            // Assert
            engine.Start();
        }
    }
}
