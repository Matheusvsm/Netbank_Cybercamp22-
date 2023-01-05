using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class BoletoPaymentServiceFactory : IBoletoPaymentServiceFactory
    {
        private IServiceProvider _provider;

        public BoletoPaymentServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBoletoPaymentService Create()
        {
            return _provider.GetService<IBoletoPaymentService>();
        }
    }
}