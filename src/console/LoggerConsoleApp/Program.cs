using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using WWS.Logger.FileProvider;

namespace LoggerConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = ConfigureServices().BuildServiceProvider();
            var logger = services.GetService<ILogger<Program>>();
            logger.LogInformation("Hello World!");
            Console.ReadLine();
        }

        static IConfiguration LoadConfiguration()
        {
            var settingsFilename = "appsetting.json";
            var moduleFileName = Process.GetCurrentProcess().MainModule.FileName;
            var currDir = Path.GetDirectoryName(moduleFileName);
            var builder = new ConfigurationBuilder()
                .SetBasePath(currDir)
                .AddJsonFile(settingsFilename);
            return builder.Build();
        }

        static IServiceCollection ConfigureServices()
        {
            var config = LoadConfiguration();
            var services = new ServiceCollection();
            services
                .AddLogging(configure =>
                {
                    configure
                    .AddConsole()
                    .AddWWSFileLogger();
                });                
            services.AddScoped<Program>();
            return services;
        }
    }
}
