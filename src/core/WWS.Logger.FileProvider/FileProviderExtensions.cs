using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WWS.Logger.FileProvider
{
    public static class FileProviderExtensions
    {
        public static ILoggingBuilder AddWWSFileLogger(this ILoggingBuilder builder, ServiceLifetime scope = ServiceLifetime.Scoped) 
        {

            //services.Add(new ServiceDescriptor(typeof(IContentFactory), typeof(ContentFactory), ServiceLifetime.Singleton));
            //services.Add(new ServiceDescriptor(typeof(IApi), typeof(Api), scope));
            //services.Add(new ServiceDescriptor(typeof(Config), typeof(Config), scope));

            var serviceDescriptor = new ServiceDescriptor(typeof(ILoggerProvider), typeof(FileLoggerProvider), scope);

            builder.Services.Add(serviceDescriptor);
            return builder;
        }
    }
}
