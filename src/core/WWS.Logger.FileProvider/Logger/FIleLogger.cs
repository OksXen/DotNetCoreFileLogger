using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;


namespace WWS.Logger.FileProvider
{
    public class FIleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new NotDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            var path = $".\\{DateTime.Now.ToString("mm")}_filelog.txt";
            var contents = new List<string>() { message };

            File.AppendAllLines(path, contents);
        }
    }

    public class NotDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
