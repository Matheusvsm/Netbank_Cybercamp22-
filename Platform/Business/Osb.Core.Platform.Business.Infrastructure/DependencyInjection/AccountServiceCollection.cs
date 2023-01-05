using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class AccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountServiceFactory, AccountServiceFactory>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountRepositoryFactory, AccountRepositoryFactory>();
        }
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountServiceFactory, AccountServiceFactory>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAccountRepositoryFactory, AccountRepositoryFactory>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
        }
    }
}