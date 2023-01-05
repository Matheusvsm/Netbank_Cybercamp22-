using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class TaxPaymentServiceFactory : ITaxPaymentServiceFactory
    {
        private IServiceProvider _provider;

        public TaxPaymentServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITaxPaymentService Create() => _provider.GetService<ITaxPaymentService>();
    }
}