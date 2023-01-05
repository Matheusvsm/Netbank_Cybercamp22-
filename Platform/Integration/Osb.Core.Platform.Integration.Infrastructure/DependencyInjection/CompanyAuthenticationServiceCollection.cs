using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Repository;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Repository;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class CompanyAuthenticationServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ICompanyAuthenticationRepository, CompanyAuthenticationRepository>();
            services.AddScoped<ICompanyAuthenticationRepositoryFactory, CompanyAuthenticationRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ICompanyAuthenticationRepository, CompanyAuthenticationRepository>();
            services.AddSingleton<ICompanyAuthenticationRepositoryFactory, CompanyAuthenticationRepositoryFactory>();
        }
    }
}