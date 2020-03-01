# TacitusLogger.DI.MicrosoftDI

> Extension for Microsoft dependency injection container that helps to configure and add TacitusLogger as a singleton.
 
Dependencies:  
* NET Standard >= 1.3   
* Microsoft.Extensions.DependencyInjection >= 1.0.0   
* TacitusLogger >= 0.3.0  
  
> Attention: `TacitusLogger.DI.MicrosoftDI` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="http://example.com/" target="_blank">package</a>:

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