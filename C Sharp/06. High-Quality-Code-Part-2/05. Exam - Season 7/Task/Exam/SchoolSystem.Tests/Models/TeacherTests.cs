using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructor_ShouldSetSubjectCorrectly_WhenInitialized()
        {
            // Arrange & Act
            var subject = Subject.Math;
            var teacher = new Teacher("Dragan", "Petkov", subject);

            // Assert
            Assert.AreEqual(subject, teacher.Subject);
        }

        [TestCase("P", "Goshev")]
        [TestCase("Pesho", "G")]
        [TestCase("PeshoPeshoPeshoPeshoPeshoPeshoPesho", "Goshev")]
        [TestCase("Pesho", "GoshevGoshevGoshevGoshevGoshevGoshevGoshev")]
        [TestCase("123", "Goshev")]
        [TestCase("Pesho", "123")]
        public void Constructor_ShouldThrowArgumentException_WhenPassedFirstOrLastNameAreInvalid(string firstName, string lastName)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, Subject.Math));
        }

        [Test]
        public void AddMark_ShouldThrowOutOfRangeException_WhenStudentHasMoreThanMaxNumberOfMarks()
        {
            // Arrange
            var student = new Mock<IStudent>();
            var teacher = new Teacher("Dragan", "Petkov", Subject.Math);
            var mark = new Mock<IMark>();

            // Act
            var listOfMarks = Enumerable.Repeat(mark.Object, 20).ToList();
            student.Setup(m => m.Marks).Returns(listOfMarks);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => teacher.AddMark(student.Object, 5));
        }

        [Test]
        public void AddMark_ShouldAddMarkToTheStudent_WhenPassedMarkIsValid()
        {
            // Arrange
            var subject = Subject.Math;
            var value = 4;
            var student = new Mock<IStudent>();
            var teacher = new Teacher("Dragan", "Petkov", Subject.Math);

            // Act
            student.Setup(m => m.Marks).Returns(new List<IMark>());
            teacher.AddMark(student.Object, value);

            // Assert
            Assert.AreEqual(subject, student.Object.Marks.Single().Subject);
            Assert.AreEqual(value, student.Object.Marks.Single().Value);
        }
    }
}
