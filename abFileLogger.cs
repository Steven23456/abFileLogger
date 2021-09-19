using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace abLogger
{
    public class abFileLogger : ILogger
    {
        private static object _lock = new object();
        private readonly string _name;
        private readonly Func<abFileLoggerConfiguration> _getCurrentConfig;

        public abFileLogger(
            string name,
            Func<abFileLoggerConfiguration> getCurrentConfig) =>
            (_name, _getCurrentConfig) = (name, getCurrentConfig);


        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    string fullFilePath = _getCurrentConfig().fullLogName;

                    var n = Environment.NewLine;
                    string exc = "";
                    if (exception != null) exc = exception.GetType() + ": " + exception.Message + n + exception.StackTrace + n;
                    var line = $"{logLevel.ToString()}: {DateTime.Now.ToString()} - {_name} - {formatter(state, exception)}{n}{exc}";
                    File.AppendAllText(fullFilePath, line);
                    
                }
            }
        }
    }
}
