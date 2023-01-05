using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class TaxPaymentRepositoryFactory : ITaxPaymentRepositoryFactory
    {
        private IServiceProvider _provider;

        public TaxPaymentRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITaxPaymentRepository Create() => _provider.GetService<ITaxPaymentRepository>();
    }
}