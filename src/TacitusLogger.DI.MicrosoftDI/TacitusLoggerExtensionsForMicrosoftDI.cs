using Microsoft.Extensions.DependencyInjection;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.MicrosoftDI
{
    public static class TacitusLoggerExtensionsForMicrosoftDI
    {
        public static ILoggerBuilder TacitusLogger(this IServiceCollection container, string loggerName)
        {
            return new CustomizedLoggerBuilder(loggerName, null, (lg) => container.AddSingleton<ILogger>(lg));
        }
        public static ILoggerBuilder TacitusLogger(this IServiceCollection container)
        {
            return TacitusLogger(container, null);
        }
    }
}
