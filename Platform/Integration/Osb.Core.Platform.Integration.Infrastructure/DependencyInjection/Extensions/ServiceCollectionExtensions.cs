using Microsoft.Extensions.DependencyInjection;
namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedIntegrationFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddScopedFactories(services);
            BankServiceCollection.AddScopedFactories(services);
            CompanyAuthenticationServiceCollection.AddScopedFactories(services);
            InternalTransferServiceCollection.AddScopedFactories(services);
            MoneyTransferServiceCollection.AddScopedFactories(services);
            BoletoPaymentServiceCollection.AddScopedFactories(services);
            NotificationServiceCollection.AddScopedFactories(services);
            HashCodeServiceCollection.AddScopedFactories(services);
            TagServiceCollection.AddScopedFactories(services);
            CardServiceCollection.AddScopedFactories(services);
            NewAccountServiceCollection.AddScopedFactories(services);
            LimitedAccountServiceCollection.AddScopedFactories(services);
            TopUpServiceCollection.AddScopedFactories(services);
            TaxPaymentServiceCollection.AddScopedFactories(services);
            IntegrationLogServiceCollection.AddScopedFactories(services);
            FutureTransactionsServiceCollection.AddScopedFactories(services);
            PixServiceCollection.AddScopedFactories(services);
            AddressServiceCollection.AddScopedFactories(services);
        }

        public static void AddSingletonIntegrationFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddSingletonFactories(services);
            BankServiceCollection.AddSingletonFactories(services);
            CompanyAuthenticationServiceCollection.AddSingletonFactories(services);
            InternalTransferServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            BoletoPaymentServiceCollection.AddSingletonFactories(services);
            NotificationServiceCollection.AddSingletonFactories(services);
            HashCodeServiceCollection.AddSingletonFactories(services);
            TagServiceCollection.AddSingletonFactories(services);
            CardServiceCollection.AddSingletonFactories(services);
            NewAccountServiceCollection.AddSingletonFactories(services);
            LimitedAccountServiceCollection.AddSingletonFactories(services);
            TopUpServiceCollection.AddSingletonFactories(services);
            TaxPaymentServiceCollection.AddSingletonFactories(services);
            IntegrationLogServiceCollection.AddSingletonFactories(services);
            FutureTransactionsServiceCollection.AddSingletonFactories(services);
            PixServiceCollection.AddSingletonFactories(services);
            AddressServiceCollection.AddSingletonFactories(services);
        }
    }
}