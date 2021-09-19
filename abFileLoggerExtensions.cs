using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System;


namespace abLogger
{
    public static class abFileLoggerExtensions
    {

        /// <summary>
        /// Adds a file provider to ILogger, see abFileLoggerConfiguration for configuration information
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>ILoggingBuilder</returns>
        public static ILoggingBuilder AddFile(
            this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, abFileLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <abFileLoggerConfiguration, abFileLoggerProvider>(builder.Services);

            return builder;
        }



        /// <summary>
        /// Adds a file provider to ILogger, see abFileLoggerConfiguration for configuration information
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configure">Optional: to configure the file settings</param>
        /// <returns>ILoggingBuilder</returns>
        public static ILoggingBuilder AddFile(
            this ILoggingBuilder builder,
            Action<abFileLoggerConfiguration> configure)
        {
            builder.AddFile();
            builder.Services.Configure(configure);
            return builder;
        }

    }
}
