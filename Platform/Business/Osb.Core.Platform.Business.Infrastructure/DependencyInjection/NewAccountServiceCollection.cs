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
    internal class NewAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<INewAccountService, NewAccountService>();
            services.AddScoped<INewAccountServiceFactory, NewAccountServiceFactory>();
            services.AddScoped<INewAccountRepositoryFactory, NewAccountRepositoryFactory>();
            services.AddScoped<INewAccountRepository, NewAccountRepository>();
            services.AddScoped<INewAccountPersonRepositoryFactory, NewAccountPersonRepositoryFactory>();
            services.AddScoped<INewAccountPersonRepository, NewAccountPersonRepository>();
            services.AddScoped<INewAccountPersonDocumentRepositoryFactory, NewAccountPersonDocumentRepositoryFactory>();
            services.AddScoped<INewAccountPersonDocumentRepository, NewAccountPersonDocumentRepository>();
            services.AddScoped<INewAccountAddressRepositoryFactory, NewAccountAddressRepositoryFactory>();
            services.AddScoped<INewAccountAddressRepository, NewAccountAddressRepository>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<INewAccountServiceFactory, NewAccountServiceFactory>();
            services.AddSingleton<INewAccountService, NewAccountService>();
            services.AddSingleton<INewAccountRepositoryFactory, NewAccountRepositoryFactory>();
            services.AddSingleton<INewAccountRepository, NewAccountRepository>();
            services.AddSingleton<INewAccountPersonRepositoryFactory, NewAccountPersonRepositoryFactory>();
            services.AddSingleton<INewAccountPersonRepository, NewAccountPersonRepository>();
            services.AddSingleton<INewAccountPersonDocumentRepositoryFactory, NewAccountPersonDocumentRepositoryFactory>();
            services.AddSingleton<INewAccountPersonDocumentRepository, NewAccountPersonDocumentRepository>();
            services.AddSingleton<INewAccountAddressRepositoryFactory, NewAccountAddressRepositoryFactory>();
            services.AddSingleton<INewAccountAddressRepository, NewAccountAddressRepository>();
        }
    }
}