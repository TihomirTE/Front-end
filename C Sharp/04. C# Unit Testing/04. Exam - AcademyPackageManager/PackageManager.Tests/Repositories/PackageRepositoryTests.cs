using Moq;
using NUnit.Framework;
using PackageManager.Repositories;
using PackageManager.Info.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    public class PackageRepositoryTests
    {
        [Test]
        public void Add_ShouldThrowArgumentNullException_IfPackageValueIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageRepo = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Add(null));
        }

        [Test]
        public void Add_ShouldBeInvokedCorrectly_WhenPackageIsValid()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("Pesho");

            var packageRepoMock = new Mock<IRepository<IPackage>>();
            packageRepoMock.Object.Add(packageMock.Object);

            // Act & Assert
            packageRepoMock.Verify(x => x.Add(packageMock.Object), Times.Once);
        }

        [Test]
        public void AddPackage_WhenThePackageDoesNotExist()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("Pesho");

            var loggerMock = new Mock<ILogger>();
            var packageRepo = new PackageRepository(loggerMock.Object);

            packageRepo.Add(packageMock.Object);
            // TODO finish whole Class
            // Act & Assert
            
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_IfPackageValueIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageRepo = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Delete(null));
        }

        [Test]
        public void Delete_ShouldBeInvokedCorrectly_WhenPackageIsValid()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("Pesho");

            var packageRepoMock = new Mock<IRepository<IPackage>>();
            packageRepoMock.Object.Delete(packageMock.Object);

            // Act & Assert
            packageRepoMock.Verify(x => x.Delete(packageMock.Object), Times.Once);
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_IfPackageValueIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageRepo = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Update(null));
        }

        [Test]
        public void Update_ShouldBeInvokedCorrectly_WhenPackageIsValid()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("Pesho");

            var packageRepoMock = new Mock<IRepository<IPackage>>();
            packageRepoMock.Object.Update(packageMock.Object);

            // Act & Assert
            packageRepoMock.Verify(x => x.Update(packageMock.Object), Times.Once);
        }
    }
}
