using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void Constructor_ShouldSetValidParametersWithoutDependenciesParameterCorrectly()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            // Act & Assert
            Assert.IsInstanceOf<Package>(package);
        }

        [Test]
        public void Constructor_ShouldSetValidParametersWithDependenciesParameterCorrectly()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();
            var collectionPackages = new Mock<ICollection<IPackage>>();
            collectionPackages.Setup(x => x.Add(packageMock.Object));

            var package = new Package("package", versionMock.Object, collectionPackages.Object);

            // Act & Assert
            Assert.IsInstanceOf<Package>(package);
        }

        [Test]
        public void Constructor_ShouldSetNameParameterCorrectly()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            // Act & Assert
            Assert.AreEqual("package", package.Name);
        }

        [Test]
        public void Constructor_ShouldSetVersionParameterCorrectly()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            // Act & Assert
            Assert.AreSame(versionMock.Object, package.Version);
        }

        [Test]
        public void Constructor_ShouldSetUrlCorrectly()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(10);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var package = new Package("package", versionMock.Object);

            // Act & Assert
            StringAssert.Contains("alpha", package.Url);
            StringAssert.Contains("10", package.Url);
        }

        [Test]
        public void CompareTo_ShouldThrowArgumentNullException_WhenOtherParameterIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void CompareTo_ShouldThrowArgumentException_WhenTheNameOfOtherParameterIsDifferentFromPackageObjectName()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("other");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherMock.Object));
        }

        [Test]
        public void CompareTo_ShouldBeInvoked_WhenOtherParameterIsValid()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(10);
            otherMock.Setup(x => x.Version.Minor).Returns(5);
            otherMock.Setup(x => x.Version.Patch).Returns(2);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act & Assert
            Assert.DoesNotThrow(() => package.CompareTo(otherMock.Object));
        }

        [Test]
        public void CompareToPassedPackage_ShouldBeHigherVersion()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(10);
            otherMock.Setup(x => x.Version.Minor).Returns(10);
            otherMock.Setup(x => x.Version.Patch).Returns(10);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act
            var result = package.CompareTo(otherMock.Object);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareToPassedPackage_ShouldBeLowerVersion()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(-10);
            otherMock.Setup(x => x.Version.Minor).Returns(-10);
            otherMock.Setup(x => x.Version.Patch).Returns(-10);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act
            var result = package.CompareTo(otherMock.Object);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareToPassedPackage_ShouldBeTheSameVersion()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(0);
            otherMock.Setup(x => x.Version.Minor).Returns(0);
            otherMock.Setup(x => x.Version.Patch).Returns(0);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act
            var result = package.CompareTo(otherMock.Object);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Equals_ShouldThrowArgumentNullException_WhenObjParameterIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void Equals_ShouldBeInvoked_WhenObjParameterIsValid()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(10);
            otherMock.Setup(x => x.Version.Minor).Returns(5);
            otherMock.Setup(x => x.Version.Patch).Returns(2);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act & Assert
            Assert.DoesNotThrow(() => package.Equals(otherMock.Object));
        }

        [Test]
        public void Equals_ShouldThrowArgumentException_WhenObjParameterIsNotFromTypeIPackage()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var obj = "object";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => package.Equals(obj));
        }

        [Test]
        public void Equals_ShouldPassedPackageBeEqualToPackageInstance()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(0);
            otherMock.Setup(x => x.Version.Minor).Returns(0);
            otherMock.Setup(x => x.Version.Patch).Returns(0);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act & Assert
            Assert.IsTrue(package.Equals(otherMock.Object));
        }

        [Test]
        public void Equals_ShouldPassedPackageNotBeEqualToPackageInstance()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();
            var package = new Package("package", versionMock.Object);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("package");
            otherMock.Setup(x => x.Version.Major).Returns(10);
            otherMock.Setup(x => x.Version.Minor).Returns(10);
            otherMock.Setup(x => x.Version.Patch).Returns(10);
            otherMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            // Act & Assert
            Assert.IsFalse(package.Equals(otherMock.Object));
        }
    }
}
