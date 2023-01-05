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
    internal class ProfileServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileServiceFactory, ProfileServiceFactory>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileRepositoryFactory, ProfileRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IProfileService, ProfileService>();
            services.AddSingleton<IProfileServiceFactory, ProfileServiceFactory>();
            services.AddSingleton<IProfileRepository, ProfileRepository>();
            services.AddSingleton<IProfileRepositoryFactory, ProfileRepositoryFactory>();
        }
    }
}