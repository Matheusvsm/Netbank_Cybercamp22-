using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class HashCodeServiceFactory : Interfaces.IHashCodeServiceFactory
    {
        private IServiceProvider _provider;

        public HashCodeServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IHashCodeService Create() => _provider.GetService<IHashCodeService>();
    }
} 