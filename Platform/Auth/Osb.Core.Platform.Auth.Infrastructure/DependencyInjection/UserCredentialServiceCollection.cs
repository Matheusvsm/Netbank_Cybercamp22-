using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class UserCredentialServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IUserCredentialRepository, UserCredentialRepository>();
            services.AddScoped<IUserCredentialRepositoryFactory, UserCredentialRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IUserCredentialRepository, UserCredentialRepository>();
            services.AddSingleton<IUserCredentialRepositoryFactory, UserCredentialRepositoryFactory>();
        }
    }
}