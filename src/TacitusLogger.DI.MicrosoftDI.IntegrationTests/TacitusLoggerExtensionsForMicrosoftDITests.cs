using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework; 

namespace TacitusLogger.DI.MicrosoftDI.IntegrationTests
{ 
    [TestFixture]
    public class TacitusLoggerExtensionsForMicrosoftDITests
    {
        [Test]
        public void When_Logger_Is_Not_Built_ServiceProvider_Does_Not_Have_ILogger_Binding()
        {
            // Arrange 
            IServiceCollection serviceCollection = new ServiceCollection();
            var loggerBuilder = serviceCollection.TacitusLogger("logger1");
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var logger = serviceProvider.GetService<ILogger>();

            // Assert
            Assert.IsNull(logger); 
        }
        [Test]
        public void When_Logger_Is_Built_ServiceProvider_Has_ILogger_Binding()
        {
            // Arrange 
            IServiceCollection serviceCollection = new ServiceCollection();
            var loggerBuilder = serviceCollection.TacitusLogger("logger1");
            loggerBuilder.BuildLogger();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act 
            ILogger logger = serviceProvider.GetService<ILogger>();

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOf<Logger>(logger);
        }
        [Test]
        public void ILogger_Binding_Is_Singleton()
        {
            // Arrange
            IServiceCollection serviceCollection = new ServiceCollection();
            ILogger loggerFromBuilder = serviceCollection.TacitusLogger("logger1").BuildLogger();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act 
            ILogger loggerInstance1 = serviceProvider.GetService<ILogger>();
            ILogger loggerInstance2 = serviceProvider.GetService<ILogger>();
            ILogger loggerInstance3 = serviceProvider.GetService<ILogger>();

            // Assert
            Assert.AreEqual(loggerFromBuilder, loggerInstance1);
            Assert.AreEqual(loggerFromBuilder, loggerInstance2);
            Assert.AreEqual(loggerFromBuilder, loggerInstance3);
        }
    }
}
