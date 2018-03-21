using Academy.Core.Providers;
using Academy.Interceptors;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;

namespace Academy.UnitTests.Interceptors.AuthInterceptorTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        public void ProceedInvocation_WhenUserIsAuth()
        {
            // Arrange
            var authProviderMock = new Mock<IAuthProvider>();
            var invocationMock = new Mock<IInvocation>();

            authProviderMock.Setup(a => a.IsUserAuth()).Returns(true);
            var authInterceptor = new AuthInterceptor(authProviderMock.Object);

            // Act
            authInterceptor.Intercept(invocationMock.Object);

            // Assert
            invocationMock.Verify(p => p.Proceed(), Times.Once());
        }

        [Test]
        public void NotProceedInvocation_WhenUserIsNotAuth()
        {
            // Arrange
            var authProviderMock = new Mock<IAuthProvider>();
            var invocationMock = new Mock<IInvocation>();

            authProviderMock.Setup(a => a.IsUserAuth()).Returns(false);
            var authInterceptor = new AuthInterceptor(authProviderMock.Object);

            // Act
            authInterceptor.Intercept(invocationMock.Object);

            // Assert
            invocationMock.Verify(p => p.Proceed(), Times.Never());
        }
    }
}
