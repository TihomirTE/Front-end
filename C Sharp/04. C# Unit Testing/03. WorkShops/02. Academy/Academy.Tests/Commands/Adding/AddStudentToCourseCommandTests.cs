
namespace Academy.Tests.Commands.Adding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using Academy.Tests.Commands.Adding.Mock;

    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Constructor_IfFactoryIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedEngine = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommandMock(null, mockedEngine.Object));
        }

        [Test]
        public void Constructor_IfEngineIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommandMock(mockedFactory.Object, null));
        }

        [Test]
        public void Constructor_IfEngineIsNotNull_ShouldAssignCorrectlyPassedValues()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            // Act
            var result = new AddStudentToCourseCommandMock(mockedFactory.Object, mockedEngine.Object);

            // Assert
            Assert.AreSame(mockedEngine.Object, result.Engine);
        }

        [Test]
        public void Constructor_IfFactoryIsNotNull_ShouldAssignCorrectlyPassedValues()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            // Act
            var result = new AddStudentToCourseCommandMock(mockedFactory.Object, mockedEngine.Object);

            // Assert
            Assert.AreSame(mockedFactory.Object, result.AcademyFactory);
        }

        [Test]
        public void Execute_WhenTheCourseIsInvalid_ShouldThrowArgumentExeption()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Username).Returns("Moli");
            mockedEngine.Setup(x => x.Students).Returns(new List<IStudent> { mockedStudent.Object });

            var mockedCourse = new Mock<ICourse>();
            var mockedSeason = new Mock<ISeason>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent> { mockedStudent.Object });
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent> { mockedStudent.Object });

            mockedSeason.Setup(x => x.Courses).Returns(new List<ICourse>() { mockedCourse.Object });

            mockedEngine.Setup(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });

            var result = new AddStudentToCourseCommand(mockedFactory.Object, mockedEngine.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => result.Execute(new List<string>() { "Moli", "0", "0", "empty" }));
        }

        [Test]
        public void Execute_WhenTheCourseFormIsOnsite_ShouldAddStudent()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Username).Returns("Moli");
            mockedEngine.Setup(x => x.Students).Returns(new List<IStudent> { mockedStudent.Object });

            var mockedCourse = new Mock<ICourse>();
            var mockedSeason = new Mock<ISeason>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            mockedSeason.Setup(x => x.Courses).Returns(new List<ICourse>() { mockedCourse.Object });

            mockedEngine.Setup(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToCourseCommand(mockedFactory.Object, mockedEngine.Object);

            // Act
            command.Execute(new List<string>() { "Moli", "0", "0", "onsite" });

            //  Assert
            Assert.AreEqual(1, mockedCourse.Object.OnsiteStudents.Count());
        }

        [Test]
        public void Execute_WhenTheCourseFormIsOnline_ShouldAddStudent()
        {
            // Arrange
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Username).Returns("Moli");
            mockedEngine.Setup(x => x.Students).Returns(new List<IStudent> { mockedStudent.Object });

            var mockedCourse = new Mock<ICourse>();
            var mockedSeason = new Mock<ISeason>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            mockedSeason.Setup(x => x.Courses).Returns(new List<ICourse>() { mockedCourse.Object });

            mockedEngine.Setup(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToCourseCommand(mockedFactory.Object, mockedEngine.Object);

            // Act
            command.Execute(new List<string>() { "Moli", "0", "0", "online" });

            //  Assert
            Assert.AreEqual(1, mockedCourse.Object.OnlineStudents.Count());
        }

    }
}
