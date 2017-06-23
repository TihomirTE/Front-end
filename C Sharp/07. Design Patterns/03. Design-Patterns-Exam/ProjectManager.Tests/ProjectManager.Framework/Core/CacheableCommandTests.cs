using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests.ProjectManager.Framework.Core
{
    [TestFixture]
    public class CacheableCommandTests
    {
        [Test]
        public void ExecuteShould_ThrowsArgumentNullException_WhenParametersAreNull()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();
            var cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => cacheableCommand.Execute(null));
        }

        [Test]
        public void ExecuteShould_ResetTheCacheAndExecuteCommand_WhenTheCacheIsExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            cachingServiceMock.SetupGet(s => s.IsExpired).Returns(true);
            cachingServiceMock.Setup(s => s.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));
            cachingServiceMock.Setup(s => s.ResetCache());
            commandMock.Setup(c => c.Execute(It.IsAny<List<string>>())).Returns("result");

            var cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            var result = cacheableCommand.Execute(new List<string>());

            // Assert
            cachingServiceMock.Verify(c => c.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            cachingServiceMock.Verify(c => c.ResetCache(), Times.Once);
            commandMock.Verify(c => c.Execute(It.IsAny<List<string>>()), Times.Once);
            Assert.AreEqual("result", result);
        }

        [Test]
        public void ExecuteShould_GetTheCachedValue_WhenTheCacheIsNotExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            cachingServiceMock.SetupGet(c => c.IsExpired).Returns(false);
            cachingServiceMock.Setup(c => c.GetCacheValue(It.IsAny<string>(), It.IsAny<string>())).Returns("result");

            var command = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            var result = command.Execute(new List<string>());

            // Assert
            cachingServiceMock.Verify(c => c.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.AreEqual("result", result);
        }
    }
}
