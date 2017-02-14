namespace Academy.Tests.Commands.Adding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using Academy.Tests.Commands.Adding.Mock;

    [TestFixture]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void Constructor_IfFactoryIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedEngine = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, mockedEngine.Object));
        }

        [Test]
        public void Constructor_IfEngineIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(mockedFactory.Object, null));
        }

        [Test]
        public void Constructor_IfFactoryIsNotNull_ShouldAssignItCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            // Act
            var result = new AddStudentToSeasonCommnadMock(mockedFactory.Object, mockedEngine.Object);

            // Assert
            Assert.AreSame(mockedFactory.Object, result.AcademyFactory);
        }

        [Test]
        public void Constructor_IfEngineIsNotNull_ShouldAssignItCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            // Act
            var result = new AddStudentToSeasonCommnadMock(mockedFactory.Object, mockedEngine.Object);

            // Assert
            Assert.AreSame(mockedEngine.Object, result.Engine);
        }

        [Test]
        public void Execute_IfStudentIsAlreadyPartOfThatSeason_ShouldThrowArgumentException()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(s => s.Username).Returns("Pesho");
            mockedEngine.Setup(s => s.Students).Returns(new List<IStudent> { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();
            mockedSeason.Setup(season => season.Students).Returns(new List<IStudent> { new Student("Pesho", Track.Frontend)});
            mockedEngine.Setup(s => s.Seasons).Returns(new List<ISeason> { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(mockedFactory.Object, mockedEngine.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string> { "Pesho", "0" }));
        }

        [Test]
        public void Execute_WhenTheStudentIsNotInTheSeason_ShouldAddCorrecltyStudent()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedSeason = new Mock<ISeason>();

            var mockedStudent1 = new Mock<IStudent>();
            mockedStudent1.SetupGet(s => s.Username).Returns("Pesho");
            mockedEngine.SetupGet(s => s.Students).Returns(new List<IStudent> { mockedStudent1.Object });


            var mockedStudent2 = new Mock<IStudent>();
            mockedStudent2.SetupGet(s => s.Username).Returns("Gosho");

            mockedSeason.SetupGet(s => s.Students).Returns(new List<IStudent> { mockedStudent2.Object });
            mockedEngine.Setup(s => s.Seasons).Returns(new List<ISeason> { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(mockedFactory.Object, mockedEngine.Object);

            // Act
            command.Execute(new List<string>() { "Pesho", "0" });

            // Assert
            Assert.AreEqual(2, mockedSeason.Object.Students.Count());


        }

        [Test]
        public void Execute_WhenTheStudentIsNotInTheSeason_ShouldReturnSuccessMessage()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var mockedStudent1 = new Mock<IStudent>();
            mockedStudent1.SetupGet(s => s.Username).Returns("Pesho");
            mockedEngine.Setup(s => s.Students).Returns(new List<IStudent> { mockedStudent1.Object });

            var mockedSeason = new Mock<ISeason>();

            var mockedStudent2 = new Mock<IStudent>();
            mockedStudent2.SetupGet(s => s.Username).Returns("Gosho");

            mockedSeason.SetupGet(s => s.Students).Returns(new List<IStudent> { mockedStudent2.Object });

            mockedEngine.Setup(s => s.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(mockedFactory.Object, mockedEngine.Object);

            // Act
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            // Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("Season 0", result);
        }
    }
}


