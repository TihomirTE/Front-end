namespace Academy.Tests.Models
{
    using Moq;
    using NUnit.Framework;

    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;

    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_ItteratesOvertheCollectionWithTrainers()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var mockedTrainer = new Mock<ITrainer>();
            mockedTrainer.Setup(t => t.ToString()).Returns("");
            season.Trainers.Add(mockedTrainer.Object);

            // Act
            season.ListUsers();

            // Assert
            mockedTrainer.Verify(t => t.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ItteratesOvertheCollectionWithStudents()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var mockedStudent = new Mock<IStudent>();
            season.Students.Add(mockedStudent.Object);
            mockedStudent.Setup(s => s.ToString()).Returns("something");

            // Act
            season.ListUsers();

            // Assert
            mockedStudent.Verify(s => s.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_IfTheCollectionIsEmpty_ShouldReturnMessage()
        {
            // Arrenge
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            // Act & Assert
            StringAssert.Contains("no users", season.ListUsers());
        }

        [Test]
        public void ListCourses_ItteratesOverTheCollection()
        {
            // Arrenge
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var mockedCourse = new Mock<ICourse>();
            mockedCourse.Setup(c => c.ToString()).Returns("course");
            season.Courses.Add(mockedCourse.Object);

            // Act
            season.ListCourses();

            // Assert
            mockedCourse.Verify(c => c.ToString(), Times.Once);
        }

        [Test]
        public void ListCourses_IfTheCollectionIsEmpty_ShouldReturnMessage()
        {
            // Arrenge
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            // Act & Assert
            StringAssert.Contains("no courses", season.ListCourses());
        }
    }
}
