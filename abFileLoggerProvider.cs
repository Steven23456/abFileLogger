using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;

namespace abLogger
{
    public class abFileLoggerProvider : ILoggerProvider
    {
        private readonly IDisposable _onChangeToken;
        private abFileLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, abFileLogger> _loggers = new();

        public abFileLoggerProvider(IOptionsMonitor<abFileLoggerConfiguration> config)
        {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updateConfig => _currentConfig = updateConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new abFileLogger(name, GetCurrentConfig));

        private abFileLoggerConfiguration GetCurrentConfig() => _currentConfig;


        public void Dispose()
        {
            _loggers.Clear();
            _onChangeToken.Dispose();
        }
    }
}
