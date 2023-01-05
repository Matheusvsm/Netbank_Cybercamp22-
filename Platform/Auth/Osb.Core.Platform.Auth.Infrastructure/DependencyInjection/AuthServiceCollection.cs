using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions
{
    internal class AuthServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAuthServiceFactory, AuthServiceFactory>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepositoryFactory, AuthRepositoryFactory>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepositoryFactory, UserRepositoryFactory>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCredentialLogRepositoryFactory, UserCredentialLogRepositoryFactory>();
            services.AddScoped<IUserCredentialLogRepository, UserCredentialLogRepository>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAuthServiceFactory, AuthServiceFactory>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IAuthRepositoryFactory, AuthRepositoryFactory>();
            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<IUserRepositoryFactory, UserRepositoryFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserCredentialLogRepositoryFactory, UserCredentialLogRepositoryFactory>();
            services.AddSingleton<IUserCredentialLogRepository, UserCredentialLogRepository>();
        }

        public static void AddTransientFactories(IServiceCollection services)
        {
            services.AddTransient<IAuthServiceFactory, AuthServiceFactory>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}