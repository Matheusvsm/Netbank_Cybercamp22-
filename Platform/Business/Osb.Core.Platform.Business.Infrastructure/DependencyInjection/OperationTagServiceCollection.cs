using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure
{
    internal class OperationTagServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IOperationTagRepository, OperationTagRepository>();
            services.AddScoped<IOperationTagRepositoryFactory, OperationTagRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IOperationTagRepository, OperationTagRepository>();
            services.AddSingleton<IOperationTagRepositoryFactory, OperationTagRepositoryFactory>();
        }
    }
}