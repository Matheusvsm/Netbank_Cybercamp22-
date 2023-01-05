using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class AdditionalAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAdditionalAccountRepository, AdditionalAccountRepository>();
            services.AddScoped<IAdditionalAccountRepositoryFactory, AdditionalAccountRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAdditionalAccountRepository, AdditionalAccountRepository>();
            services.AddSingleton<IAdditionalAccountRepositoryFactory, AdditionalAccountRepositoryFactory>();
        }
    }
}