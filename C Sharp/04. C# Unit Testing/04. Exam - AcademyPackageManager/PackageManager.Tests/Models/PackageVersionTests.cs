using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageVersionTests
    {
        [Test]
        public void Constructor_ShouldSetPassedValuesCorrectly()
        {
            // Arrange
            var packageVersion = new PackageVersion(10, 5, 3, VersionType.alpha);

            // Act & Assert
            Assert.IsInstanceOf<PackageVersion>(packageVersion);
        }

        [Test]
        public void Constructor_ShouldSetMajorCorrectly()
        {
            // Arrange
            var packageVersion = new PackageVersion(10, 5, 3, VersionType.alpha);

            // Act & Assert
            Assert.AreEqual(10, packageVersion.Major);
        }

        [Test]
        public void Constructor_WhenMajorIsSmallerThanZero_ShouldThrowArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(-1, 5, 3, VersionType.alpha));
        }
        [Test]
        public void Constructor_ShouldSetMinorCorrectly()
        {
            // Arrange
            var packageVersion = new PackageVersion(10, 5, 3, VersionType.alpha);

            // Act & Assert
            Assert.AreEqual(5, packageVersion.Minor);
        }

        [Test]
        public void Constructor_WhenMinorIsSmallerThanZero_ShouldThrowArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(10, -1, 3, VersionType.alpha));
        }

        [Test]
        public void Constructor_ShouldSetPatchCorrectly()
        {
            // Arrange
            var packageVersion = new PackageVersion(10, 5, 3, VersionType.alpha);

            // Act & Assert
            Assert.AreEqual(3, packageVersion.Patch);
        }

        [Test]
        public void Constructor_WhenPatchIsSmallerThanZero_ShouldThrowArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(10, 5, -1, VersionType.alpha));
        }

        [Test]
        public void Constructor_ShouldSetVersionTypeCorrectly()
        {
            // Arrange
            var packageVersion = new PackageVersion(10, 5, 3, VersionType.alpha);

            // Act & Assert
            Assert.AreEqual(VersionType.alpha, packageVersion.VersionType);
        }

        // TODO Check for invalid VersionType

        //[Test]
        //public void Constructor_WhenVersionTypeIsNotInCorrectType_ShouldThrowArgumentException()
        //{
        //    // Arrange & Act & Assert
        //    Assert.Throws<ArgumentException>(() => new PackageVersion(10, 5, 2, VersionType));
        //}
    }
}
