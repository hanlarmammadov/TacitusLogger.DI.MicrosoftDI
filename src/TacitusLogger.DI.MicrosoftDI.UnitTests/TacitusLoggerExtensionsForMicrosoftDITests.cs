using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.MicrosoftDI.UnitTests
{
    [TestFixture]
    public class TacitusLoggerExtensionsForMicrosoftDITests
    {
        [Test]
        public void TacitusLogger_Taking_IServiceCollection_And_Logger_Name_When_Called_Sets_LoggerName()
        {
            // Arrange 
            string loggerName = "logger1";

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForMicrosoftDI.TacitusLogger(new Mock<IServiceCollection>().Object, loggerName);

            // Assert 
            Assert.AreEqual(loggerName, loggerBuilder.LoggerName);
        }
        [Test]
        public void TacitusLogger_Taking_IServiceCollection_And_Logger_Name()
        {
            // Arrange
            var serviceCollectionMock = new Mock<IServiceCollection>();

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForMicrosoftDI.TacitusLogger(serviceCollectionMock.Object, "logger1");

            // Assert   
            serviceCollectionMock.Verify(x => x.Add(It.IsAny<ServiceDescriptor>()), Times.Never);
            var logger = loggerBuilder.BuildLogger();
            serviceCollectionMock.Verify(x => x.Add(It.Is<ServiceDescriptor>(d => d.ServiceType == typeof(ILogger) &&
                                                                                  d.ImplementationInstance == logger &&
                                                                                  d.Lifetime == ServiceLifetime.Singleton)), Times.Once);
        }
        [Test]
        public void TacitusLogger_Taking_IServiceCollection_When_Called_Sets_Default_LoggerName()
        {
            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForMicrosoftDI.TacitusLogger(new Mock<IServiceCollection>().Object);

            // Assert 
            Assert.NotNull(loggerBuilder.LoggerName);
        }
        [Test]
        public void TacitusLogger_Taking_IServiceCollection()
        {
            // Arrange
            var serviceCollectionMock = new Mock<IServiceCollection>();

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForMicrosoftDI.TacitusLogger(serviceCollectionMock.Object);

            // Assert  
            serviceCollectionMock.Verify(x => x.Add(It.IsAny<ServiceDescriptor>()), Times.Never);
            var logger = loggerBuilder.BuildLogger();
            serviceCollectionMock.Verify(x => x.Add(It.Is<ServiceDescriptor>(d => d.ServiceType == typeof(ILogger) &&
                                                                                  d.ImplementationInstance == logger &&
                                                                                  d.Lifetime == ServiceLifetime.Singleton)), Times.Once);
        }
    }
}
