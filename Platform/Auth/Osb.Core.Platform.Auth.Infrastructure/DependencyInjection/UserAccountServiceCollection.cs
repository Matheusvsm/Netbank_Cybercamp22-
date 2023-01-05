using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;


namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class UserAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserAccountRepositoryFactory, UserAccountRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IUserAccountRepository, UserAccountRepository>();
            services.AddSingleton<IUserAccountRepositoryFactory, UserAccountRepositoryFactory>();
        }
    }
}