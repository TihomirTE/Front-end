using Moq;
using NUnit.Framework;
using ProjectManager.Common;
using ProjectManager.Framework.Services;
using ProjectManager.Tests.ProjectManager.Framework.Services.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Tests.ProjectManager.Framework.Services.CachingServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throws_WhenTimeSpanIsLessThanZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(TimeSpan.FromSeconds(-1)));
        }

        [Test]
        public void SetProperInitialDateTimeForExpering()
        {
            // Arrange
            var returnDate = new DateTime(2017, 5, 20, 20, 00, 00);

            var dateTimeMock = new Mock<DateTimeProvider>();
            dateTimeMock.SetupGet(t => t.UtcNow).Returns(returnDate);

            DateTimeProvider.Current = dateTimeMock.Object;

            // Act
            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(It.IsAny<double>()));

            // Assert
            Assert.AreEqual(returnDate, cachingService.DateTimeExpiring);
        }

        [Test]
        public void InitializeCacheWithEmptyDictionary()
        {
            // Act & Arrange
            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(It.IsAny<double>()));

            // Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, object>), cachingService.CacheStorage);
            Assert.AreEqual(0, cachingService.CacheStorage.Count);
        }

        [TearDown]
        public void ResetDateTimeProvider()
        {
            DateTimeProvider.ResetToDefault();
        }
    }
}
