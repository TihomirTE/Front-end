namespace Academy.Tests.Models
{
    using System;
    using System.Collections.Generic;

    using Moq;
    using NUnit.Framework;

    using Academy.Models;
    using Academy.Models.Contracts;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Constructor_WhenNameIsPassedCorrectly_ShouldAssignTheObjectCorrectly()
        {
            // Arrange & Act
            var correctName = new Course("Correct name", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Assert
            Assert.AreEqual("Correct name", correctName.Name);
        }

        // TODO - more test for the contructor and the properties

        [Test]
        public void Constructor_ShouldInitializeTheCollectionOnlineStudents()
        {
            // Arrange
            var correctName = new Course("Correct name", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Act & Assert
            Assert.IsInstanceOf(typeof(IList<IStudent>), correctName.OnlineStudents);
        }

        [Test]
        public void Constructor_ShouldInitializeTheCollectionLectures()
        {
            // Arrange
            var correctName = new Course("Correct name", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Act & Assert
            Assert.IsInstanceOf(typeof(IList<ILecture>), correctName.Lectures);
        }

        [TestCase("so")]
        [TestCase("very very very long long long name name name long long long long")]
        public void Constructor_WhenThePassedNameIsInvalid_ShouldThrowArgumentException(string name)
        {
            // Arrange
            var correctName = new Course("Name", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => correctName.Name = name);
        }

        [Test]
        public void Constructor_WhenNameIsPassedCorrectly_ShouldNotThrowException()
        {
            // Arrange & Act
            var correctName = new Course("Correct name", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Assert
            Assert.AreEqual("Correct name", correctName.Name);
        }

        [Test]
        public void Constructor_WhenNameIsPassedCorrectly_ShouldAssignName()
        {
            // Arrange & Act
            var correctName = new Course("Correct", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));
            var name = "Correct name";

            // Assert
            Assert.AreEqual("Correct name", correctName.Name = name);
        }

        [Test]
        public void ToString_WhenCollectionIsNotEmpty_ItterateOverTheCollection()
        {
            // Arrange
            var course = new Course("Correct", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));
            var mockedLectures = new Mock<ILecture>();

            mockedLectures.Setup(l => l.ToString());
            course.Lectures.Add(mockedLectures.Object);

            // Act
            course.ToString();

            // Assert
            mockedLectures.Verify(l => l.ToString(), Times.Once);

        }

        [Test]
        public void ToString_WhenCollectionIsEmpty_ShouldReturnTheCorrectMessage()
        {
            // Arrange
            var course = new Course("Correct", 4, new DateTime(2017, 01, 01), new DateTime(2017, 12, 31));

            // Act & Assert
            StringAssert.Contains("no lectures", course.ToString());
        }
    }
}
