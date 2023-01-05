using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class OperationAttachmentServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IOperationAttachmentRepository, OperationAttachmentRepository>();
            services.AddScoped<IOperationAttachmentRepositoryFactory, OperationAttachmentRepositoryFactory>();
        }
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IOperationAttachmentRepository, OperationAttachmentRepository>();
            services.AddSingleton<IOperationAttachmentRepositoryFactory, OperationAttachmentRepositoryFactory>();
        }
    }
}