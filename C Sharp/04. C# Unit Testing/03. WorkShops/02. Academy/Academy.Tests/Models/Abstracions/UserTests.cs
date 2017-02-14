namespace Academy.Tests.Models.Abstracions
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldAssignPassedValues()
        {
            // Arrange
            var user = new MockedUser("Pesho");

            // Act & Assert
            Assert.AreEqual("Pesho", user.Username);
        }

        [TestCase("Pe")]
        [TestCase("very very long long Username")]
        public void Username_WhenPassedInavalidValue_ShouldThrowArgumentException(string username)
        {
            var user = new MockedUser("username");

            Assert.Throws<ArgumentException>(() => user.Username = username);
        }

        [Test]
        public void WhenPassedValidUsername_ShouldNotThrowException()
        {
            // Arrange
            var user = new MockedUser("Pesho");

            // Act & Assert
            Assert.AreEqual("Pesho", user.Username);
        }

        [Test]
        public void WhenPassedValidUsername_ShouldCorrectlyAssignIt()
        {
            // Arrange
            var user = new MockedUser("Pesho");
            var username = "Dragan";

            // Act & Assert
            Assert.AreEqual("Dragan", user.Username = username);
        }
    }
}
