using Castle.Core.Logging;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Constructor_ShouldSetValidParametersWithoutPackagesParameterCorrectly()
        {
            // Arrange
            var project = new Project("project", "Sofia");

            // Act & Assert
            Assert.IsInstanceOf<Project>(project);

        }

        [Test]
        public void Constructor_ShouldSetValidParametersWithPackagesParameterCorrectly()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            var packagesRepositoryMock = new Mock<IRepository<IPackage>>();
            packagesRepositoryMock.Setup(x => x.Add(packageMock.Object));
            
            // Act
            var project = new Project("project", "Sofia", packagesRepositoryMock.Object);

            // Assert
            Assert.IsInstanceOf<Project>(project);

        }

        [Test]
        public void Name_ShouldBeSetCorreclty()
        {
            // Arrange
            var project = new Project("project", "Sofia");

            // Act & Assert
            Assert.AreEqual("project", project.Name);
        }
        [Test]
        public void Location_ShouldBeSetCorreclty()
        {
            // Arrange
            var project = new Project("project", "Sofia");

            // Act & Assert
            Assert.AreEqual("Sofia", project.Location);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullExcpetion_WhenANameIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(null, "Sofia"));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullExcpetion_WhenALocationIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project("project", null));
        }
    }
}
