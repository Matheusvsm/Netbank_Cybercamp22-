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
    internal class HashCodeServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IHashCodeService, HashCodeService>();
            services.AddScoped<IHashCodeServiceFactory, HashCodeServiceFactory>();
            services.AddScoped<IHashCodeRepository, HashCodeRepository>();
            services.AddScoped<IHashCodeRepositoryFactory, HashCodeRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IHashCodeServiceFactory, HashCodeServiceFactory>();
            services.AddSingleton<IHashCodeService, HashCodeService>();
            services.AddSingleton<IHashCodeRepositoryFactory, HashCodeRepositoryFactory>();
            services.AddSingleton<IHashCodeRepository, HashCodeRepository>();
        }
    }
}