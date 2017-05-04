using Moq;
using NUnit.Framework;
using SchoolSystem.Enum;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructor_ShouldSetGradeProperty_WhenInitializedCorrectly()
        {
            // Arrange & Act
            var grade = Grade.First;
            var student = new Student("Ivan", "Ivanov", grade);

            // Assert
            Assert.AreEqual(grade, student.Grade);
        }

        [Test]
        public void Constructor_ShouldSetMarksCollectionProperly_WhenInitializedCorrectly()
        {
            // Arrange
            var student = new Student("Ivan", "Ivanov", Grade.First);

            // Act & Assert
            Assert.AreNotEqual(null, student.Marks);
        }

        [Test]
        public void ListMarks_ShouldReturnErrorMessage_WhenStudentHasNotMarks()
        {
            // Arrange
            var student = new Student("Ivan", "Ivanov", Grade.First);

            // Act
            var result = student.ListMarks().ToLower();

            // Assert
            Assert.That(result.Contains("no marks"));
        }

        [TestCase("marks")]
        [TestCase("bulgarian")]
        [TestCase("3")]
        public void ListMarks_ShouldReturnListMarks_WhenStudentHasMarks(string message)
        {
            // Arrange
            var mark = new Mock<IMark>();
            mark.Setup(c => c.Subject).Returns(Subject.Bulgarian);
            mark.Setup(c => c.Value).Returns(3);

            // Act
            var student = new Student("Ivan", "Ivanov", Grade.First);
            student.Marks.Add(mark.Object);

            var result = student.ListMarks().ToLower();

            // Assert
            Assert.That(result.Contains(message));
        }
    }
}
