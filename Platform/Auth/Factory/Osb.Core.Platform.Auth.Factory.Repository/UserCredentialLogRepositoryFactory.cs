using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;


namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class UserCredentialLogRepositoryFactory : Interfaces.IUserCredentialLogRepositoryFactory
    {
        private IServiceProvider _provider;

        public  UserCredentialLogRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUserCredentialLogRepository Create() 
        {
            return _provider.GetService<IUserCredentialLogRepository>();
        }
    }
}