# TacitusLogger.DI.MicrosoftDI

> Extension for Microsoft dependency injection container that helps to configure and add TacitusLogger as a singleton.
 
Dependencies:  
* NET Standard >= 1.3   
* Microsoft.Extensions.DependencyInjection >= 1.0.0   
* TacitusLogger >= 0.3.0  
  
> Attention: `TacitusLogger.DI.MicrosoftDI` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="https://www.nuget.org/packages/TacitusLogger.DI.MicrosoftDI" target="_blank">package</a>:

```powershell
PM> Install-Package TacitusLogger.DI.MicrosoftDI
```

## Examples

### Registering the Logger with DI Container
```cs
IServiceCollection serviceCollection = new ServiceCollection();
// Registering TacitusLogger with Microsoft DI as a singleton.
serviceCollection.TacitusLogger("logger1").ForAllLogs()
                                          .Console()
                                          .Add()
                                          .BuildLogger();

var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolving the dependency
var logger = serviceProvider.GetService<ILogger>();
```
Or:

```cs
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
```
---

## License

[APACHE LICENSE 2.0](https://www.apache.org/licenses/LICENSE-2.0)

## See also

TacitusLogger:  

- [TacitusLogger](https://github.com/khanlarmammadov/TacitusLogger) - A simple yet powerful .NET logging library.

Destinations:

- [TacitusLogger.Destinations.MongoDb](https://github.com/khanlarmammadov/TacitusLogger.Destinations.MongoDb) - Extension destination for TacitusLogger that sends logs to MongoDb database.
- [TacitusLogger.Destinations.RabbitMq](https://github.com/khanlarmammadov/TacitusLogger.Destinations.RabbitMq) - Extension destination for TacitusLogger that sends logs to the RabbitMQ exchanges.
- [TacitusLogger.Destinations.Email](https://github.com/khanlarmammadov/TacitusLogger.Destinations.Email) - Extension destination for TacitusLogger that sends logs as emails using SMTP protocol.
- [TacitusLogger.Destinations.EntityFramework](https://github.com/khanlarmammadov/TacitusLogger.Destinations.EntityFramework) - Extension destination for TacitusLogger that sends logs to database using Entity Framework ORM.
- [TacitusLogger.Destinations.Trace](https://github.com/khanlarmammadov/TacitusLogger.Destinations.Trace) - Extension destination for TacitusLogger that sends logs to System.Diagnostics.Trace listeners.  
  
Dependency injection:
- [TacitusLogger.DI.Ninject](https://github.com/khanlarmammadov/TacitusLogger.DI.Ninject) - Extension for Ninject dependency injection container that helps to configure and add TacitusLogger as a singleton.
- [TacitusLogger.DI.Autofac](https://github.com/khanlarmammadov/TacitusLogger.DI.Autofac) - Extension for Autofac dependency injection container that helps to configure and add TacitusLogger as a singleton.

Log contributors:

- [TacitusLogger.Contributors.ThreadInfo](https://github.com/khanlarmammadov/TacitusLogger.Contributors.ThreadInfo) - Extension contributor for TacitusLogger that generates additional info related to the thread on which the logger method was called.
- [TacitusLogger.Contributors.MachineInfo](https://github.com/khanlarmammadov/TacitusLogger.Contributors.MachineInfo) - Extension contributor for TacitusLogger that generates additional info related to the machine on which the log was produced.