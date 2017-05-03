using System;
using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Constructor_ShouldSetSubjectCorrectly_WhenInitialized()
        {
            // Arrange & Act
            var subject = Subject.Math;
            var mark = new Mark(subject, 5);

            // Assert
            Assert.AreEqual(subject, mark.Subject);
        }

        [TestCase(1.5f)]
        [TestCase(11f)]
        [TestCase(-43f)]
        public void Value_ShouldThrowArgumentOutOfRangeException_WhenPassedValueIsNotInValidRange(float value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(Subject.Bulgarian, value));
        }

        [TestCase(2f)]
        [TestCase(6f)]
        [TestCase(3.5f)]
        [TestCase(4.75f)]
        public void Value_ShouldNotThrow_WhenPassedValueIsInValidRange(float value)
        {
            Assert.DoesNotThrow(() => new Mark(Subject.Bulgarian, value));
        }
    }
}
