using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class AuthorizationTokenServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationTokenService, AuthorizationTokenService>();
            services.AddScoped<IAuthorizationTokenServiceFactory, AuthorizationTokenServiceFactory>();
            services.AddScoped<IAuthorizationTokenRepository, AuthorizationTokenRepository>();
            services.AddScoped<IAuthorizationTokenRepositoryFactory, AuthorizationTokenRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationTokenService, AuthorizationTokenService>();
            services.AddSingleton<IAuthorizationTokenServiceFactory, AuthorizationTokenServiceFactory>();
            services.AddSingleton<IAuthorizationTokenRepository, AuthorizationTokenRepository>();
            services.AddSingleton<IAuthorizationTokenRepositoryFactory, AuthorizationTokenRepositoryFactory>();
        }
    }
}