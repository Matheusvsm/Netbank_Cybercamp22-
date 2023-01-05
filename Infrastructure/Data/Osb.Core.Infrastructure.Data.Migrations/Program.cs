using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Osb.Core.Infrastructure.Data.Migrations.Models;

namespace Osb.Core.Infrastructure.Data.Migrations
{
    class Program
    {
        private static IConfiguration configuration;

        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.Development.json", false, true)
                .AddJsonFile($"appsettings.Development.json", false, true)
                .AddEnvironmentVariables();

            configuration = builder.Build();

            var services = CreateServices();
            services.GetService<MigrationStart>().Run();
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            string connectionString = configuration.GetConnectionString("core");
            Settings settings = configuration.GetSection("Settings").Get<Settings>();
            var services = new ServiceCollection();

            services.AddLogging(configure => configure.AddConsole());

            services.AddSingleton(options => settings);

            services.AddFluentMigratorCore()
                .ConfigureRunner(cfg => cfg
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Program).Assembly).For.Migrations()
                )
                .AddLogging(cfg => cfg.AddFluentMigratorConsole());

            services.AddTransient<MigrationStart>();


            return services.BuildServiceProvider(false);
        }
    }
}
