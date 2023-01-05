using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class BoletoPaymentServiceFactory : IBoletoPaymentServiceFactory
    {
        private IServiceProvider _provider;

        public BoletoPaymentServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBoletoPaymentService Create() => _provider.GetService<IBoletoPaymentService>();
    }
}