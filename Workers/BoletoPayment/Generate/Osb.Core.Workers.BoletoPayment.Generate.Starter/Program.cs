using Microsoft.Extensions.Hosting;
using Osb.Core.Platform.Common.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Infrastructure.Data.DependecyInjection.Extensions;
using Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions;
using Osb.Core.Platform.Business.Infrastructure.DependencyInjection.Extensions;
using Osb.Core.Platform.Integration.Infrastructure.DependencyInjection.Extensions;

namespace Osb.Core.Workers.BoletoPayment.Generate.Starter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    Settings settings = configuration.GetSection("Settings").Get<Settings>();
                    
                    services.AddSingleton(options => settings);
                    services.AddHostedService<Worker>();
                    services.AddSingleton<WorkerService>();
                    services.AddSingletonAuthFactories();
                    services.AddSingletonBusinessFactories();
                    services.AddSingletonIntegrationFactories();
                    services.AddSingletonDbContext();
                });
    }
}
