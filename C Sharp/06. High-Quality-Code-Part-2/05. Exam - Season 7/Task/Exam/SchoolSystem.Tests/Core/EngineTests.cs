using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Core;
using SchoolSystem.Core.Contracts;
using SchoolSystem.Core.Commands.Contracts;
using System.Linq;

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
            var terminationCommand = "End";

            // Act
            reader.Setup(c => c.ReadLine()).Returns(terminationCommand);

            // Assert
            engine.Start();
        }

        [Test]
        public void Start_ShouldThrowArgumentException_WhenThePassedCommandIsEmpty()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);
            var command = "";

            // Act
            reader.Setup(c => c.ReadLine()).Returns(command);

            // Assert
            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        [TestCase("RemoveStudent 0")]
        [TestCase("RemoveTeacher 0")]
        public void Start_ShouldNotThrow_WhenPassedOneValidTerminationCommand(string command)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);
            var terminationCommand = "End";

            // Act
            reader.SetupSequence(c => c.ReadLine())
                .Returns(command)
                .Returns(terminationCommand);
            
            // Assert
            Assert.DoesNotThrow(() => engine.Start());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallWriteLineOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);
            var terminationCommand = "End";

            // Act
            reader.SetupSequence(c => c.ReadLine())
                .Returns(command)
                .Returns(terminationCommand);

            engine.Start();

            // Assert
            writer.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallParseCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);
            var terminationCommand = "End";

            // Act
            reader.SetupSequence(c => c.ReadLine())
               .Returns(command)
               .Returns(terminationCommand);

            engine.Start();

            // Assert
            parser.Verify(c => c.ParseCommand(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallParseParametersOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);
            var terminationCommand = "End";

            // Act
            reader.SetupSequence(c => c.ReadLine())
               .Returns(command)
               .Returns(terminationCommand);

            engine.Start();

            // Assert
            parser.Verify(c => c.ParseParameters(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldExecuteTheProcessedCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var cmd = new Mock<ICommand>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            var commandParameters = command.Split(' ').ToList();
            commandParameters.RemoveAt(0);

            // Act
            reader.SetupSequence(c => c.ReadLine())
               .Returns(command)
               .Returns(terminationCommand);

            parser.Setup(c => c.ParseCommand(command)).Returns(cmd.Object);
            parser.Setup(c => c.ParseParameters(command)).Returns(commandParameters);

            engine.Start();

            // Assert
            cmd.Verify(c => c.Execute(commandParameters), Times.Once());
        }
    }
}
