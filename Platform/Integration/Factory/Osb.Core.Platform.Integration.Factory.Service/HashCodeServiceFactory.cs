using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class HashCodeServiceFactory : IHashCodeServiceFactory
    {
        private IServiceProvider _provider;

        public HashCodeServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IHashCodeService Create()
        {
            return _provider.GetService<IHashCodeService>();
        }
    }
}