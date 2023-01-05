using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class TaxPaymentServiceFactory: ITaxPaymentServiceFactory
    {
        private readonly IServiceProvider _provider;
        
        public TaxPaymentServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITaxPaymentService Create()
        {
            return _provider.GetService<ITaxPaymentService>();
        }
    }
}