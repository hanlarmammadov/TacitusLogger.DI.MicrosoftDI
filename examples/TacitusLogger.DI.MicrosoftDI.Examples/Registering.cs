using Microsoft.Extensions.DependencyInjection;
using System;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.MicrosoftDI.Examples
{
    public class Registering
    {
        public void Registering_Logger_With_DI_Container()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            // Registering TacitusLogger with Microsoft DI as a singleton.
            serviceCollection.TacitusLogger("logger1").ForAllLogs()
                                                      .Console()
                                                      .Add()
                                                      .BuildLogger();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolving the dependency
            var logger = serviceProvider.GetService<ILogger>();
        }
        public void Registering_Logger_With_DI_Container2()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            // Registering TacitusLogger with Microsoft DI as a singleton.
            ILoggerBuilder loggerBuilder = serviceCollection.TacitusLogger("logger1"); 
            loggerBuilder.ForAllLogs()
                         .Console()
                         .Add()
                         .BuildLogger();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolving the dependency
            var logger = serviceProvider.GetService<ILogger>();
        }
    }
}
