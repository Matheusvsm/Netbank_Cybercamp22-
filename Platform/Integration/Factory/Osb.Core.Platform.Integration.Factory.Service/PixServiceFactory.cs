using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class PixServiceFactory: IPixServiceFactory
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