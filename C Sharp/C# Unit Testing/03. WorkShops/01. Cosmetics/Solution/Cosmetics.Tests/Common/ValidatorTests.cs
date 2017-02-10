using Cosmetics.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Common
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenObjIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            object obj = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfNull_WhenObjIsNotNull_ShouldNotThrowAnyException()
        {
            // Arrange
            object obj = new object();

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_WhenParameterTextIsNullOrEmpty_ShouldThrowNullReferenceException(string str)
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [TestCase]
        public void CheckIfStringIsNullOrEmpty_WhenParameterTextIsNotNullOrEmpty_ShouldNotThrowNullReferenceException()
        {
            // Arrange
            string str = "something";
            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [TestCase(5, 0)]
        [TestCase(35, 20)]
        public void CheckIfStringLengthIsValid_WhenTheLengthOfTheParameterIsLowerOrGreater_ShouldThrowException(int max, int min)
        {
            // Arrange
            string str = "string";

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(str, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_WhenTheLengthOfTheParameterIsValid_ShouldNotThrowException()
        {
            // Arrange
            string str = "validString";
            int min = 0;
            int max = 20;

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(str, max, min));
        }

    }
}
