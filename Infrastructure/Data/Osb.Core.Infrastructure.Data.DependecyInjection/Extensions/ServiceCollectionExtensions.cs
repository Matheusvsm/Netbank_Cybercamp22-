using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Infrastructure.Data.Repository;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Infrastructure.Data.DependecyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedDbContext(this IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient(typeof(IDbContext<>), typeof(DbContext<>));
        }

        public static void AddSingletonDbContext(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton(typeof(IDbContext<>), typeof(DbContext<>));
        }
    }
}
