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
    internal class LimitedAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ILimitedAccountService, LimitedAccountService>();
            services.AddScoped<ILimitedAccountServiceFactory, LimitedAccountServiceFactory>();
            services.AddScoped<ILimitedAccountRepository, LimitedAccountRepository>();
            services.AddScoped<ILimitedAccountRepositoryFactory, LimitedAccountRepositoryFactory>();
            services.AddScoped<ILimitedPersonRepository, LimitedPersonRepository>();
            services.AddScoped<ILimitedPersonRepositoryFactory, LimitedPersonRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ILimitedAccountServiceFactory, LimitedAccountServiceFactory>();
            services.AddSingleton<ILimitedAccountService, LimitedAccountService>();
            services.AddSingleton<ILimitedAccountRepositoryFactory, LimitedAccountRepositoryFactory>();
            services.AddSingleton<ILimitedAccountRepository, LimitedAccountRepository>();
            services.AddSingleton<ILimitedPersonRepositoryFactory, LimitedPersonRepositoryFactory>();
            services.AddSingleton<ILimitedPersonRepository, LimitedPersonRepository>();
        }
    }
}