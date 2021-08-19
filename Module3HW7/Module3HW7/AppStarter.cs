using System;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Module3HW7
{
    public class AppStarter
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddSingleton<IFileService, FileService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviceProvider.GetService<Starter>();
            starter.Run();
        }
    }
}