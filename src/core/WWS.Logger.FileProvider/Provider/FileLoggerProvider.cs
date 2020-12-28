using Microsoft.Extensions.Logging;

namespace WWS.Logger.FileProvider
{
    [ProviderAlias("WWSFileLogger")]
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FIleLogger();
        }

        public void Dispose()
        {
           
        }
    }
}
