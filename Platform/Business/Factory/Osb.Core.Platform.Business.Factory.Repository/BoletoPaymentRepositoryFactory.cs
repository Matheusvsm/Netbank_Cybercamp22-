using System;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class BoletoPaymentRepositoryFactory : IBoletoPaymentRepositoryFactory
    {
        private IServiceProvider _provider;

        public BoletoPaymentRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBoletoPaymentRepository Create() => _provider.GetService<IBoletoPaymentRepository>();
    }
}