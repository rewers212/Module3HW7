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
                .AddTransient<LoggerService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviceProvider.GetService<Starter>();
            starter.Run();

        }
    }
}