using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedAuthFactories(this IServiceCollection services)
        {
            AuthServiceCollection.AddScopedFactories(services);
            DeviceServiceCollection.AddSingletonFactories(services);
            AuthorizationTokenServiceCollection.AddScopedFactories(services);
            UserServiceCollection.AddScopedFactories(services);
            UserCredentialServiceCollection.AddScopedFactories(services);
            UserAccountServiceCollection.AddScopedFactories(services);
            ProfileServiceCollection.AddScopedFactories(services);
            ActionFunctionServiceCollection.AddScopedFactories(services);
        }

        public static void AddTransientAuthFactories(this IServiceCollection services)
        {
            ApplicationServiceCollection.AddTransientFactories(services);
            AuthServiceCollection.AddTransientFactories(services);
            DeviceServiceCollection.AddSingletonFactories(services);
        }

        public static void AddSingletonAuthFactories(this IServiceCollection services)
        {
            ApplicationServiceCollection.AddSingletonFactories(services);
            DeviceServiceCollection.AddSingletonFactories(services);
            AuthServiceCollection.AddSingletonFactories(services);
            AuthorizationTokenServiceCollection.AddSingletonFactories(services);
            UserServiceCollection.AddSingletonFactories(services);
            UserCredentialServiceCollection.AddSingletonFactories(services);
            UserAccountServiceCollection.AddSingletonFactories(services);
            ProfileServiceCollection.AddSingletonFactories(services);
            ActionFunctionServiceCollection.AddSingletonFactories(services);
        }
    }
}