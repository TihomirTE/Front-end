using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands
{
    [TestFixture]
    public class InstallCommandTests
    {
        [Test]
        public void Constructor_ShouldSetAppropriatePassedValues()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();

            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);

            // Act & Assert
            Assert.IsInstanceOf<InstallCommand>(installCommand);
        }

        [Test]
        public void Constructor_ShouldSetAppropriateInstallerValues()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();

            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Act & Assert
            Assert.AreSame(installerMock.Object, installCommand.Installer);
        }

        [Test]
        public void Constructor_ShouldSetAppropriatePackageValues()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();

            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Act & Assert
            Assert.AreSame(packageMock.Object, installCommand.Package);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInstallerIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));
        }

        [Test]
        public void Properties_ShouldSetAppropriateOperationValues()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(x => x.Operation).Returns(Enums.InstallerOperation.Install);

            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Act
            var result = (int)installCommand.Installer.Operation;

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Execute_ShouldBeCalledFromTheInstaller()
        {
            // Arrange
            var installCommandMock = new Mock<ICommand>();
            installCommandMock.Object.Execute();

            // Act & Assert
            installCommandMock.Verify(x => x.Execute(), Times.Once);
        }
    }

}
