using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class AccountLogServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAccountLogRepository, AccountLogRepository>();
            services.AddScoped<IAccountLogRepositoryFactory, AccountLogRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAccountLogRepository, AccountLogRepository>();
            services.AddSingleton<IAccountLogRepositoryFactory, AccountLogRepositoryFactory>();
        }
    }
}