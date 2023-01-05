using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class PixServiceFactory : IPixServiceFactory
    {
        private readonly IServiceProvider _provider;

        public PixServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IPixService Create()
        {
            return _provider.GetService<IPixService>();
        }
    }
}