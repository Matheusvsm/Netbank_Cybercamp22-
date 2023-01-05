using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedBusinessFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddScopedFactories(services);
            AdditionalAccountServiceCollection.AddScopedFactories(services);
            UIFunctionServiceCollection.AddScopedFactories(services);
            BankServiceCollection.AddScopedFactories(services);
            InternalTransferServiceCollection.AddScopedFactories(services);
            OperationServiceCollection.AddScopedFactories(services);
            OperationTagServiceCollection.AddScopedFactories(services);
            BoletoPaymentServiceCollection.AddScopedFactories(services);
            MoneyTransferServiceCollection.AddScopedFactories(services);
            BankingDataServiceCollection.AddScopedFactories(services);
            AccountLogServiceCollection.AddScopedFactories(services);
            CompanyServiceCollection.AddScopedFactories(services);
            HashCodeServiceCollection.AddScopedFactories(services);
            CardServiceCollection.AddScopedFactories(services);
            FavoredServiceCollection.AddScopedFactories(services);
            TagServiceCollection.AddScopedFactories(services);
            CardServiceCollection.AddScopedFactories(services);
            NewAccountServiceCollection.AddScopedFactories(services);
            LimitedAccountServiceCollection.AddScopedFactories(services);
            TopUpServiceCollection.AddScopedFactories(services);
            TaxPaymentServiceCollection.AddScopedFactories(services);
            ExceptionLogCollection.AddScopedFactories(services);
            FutureTransactionsServiceCollection.AddScopedFactories(services);
            PixServiceCollection.AddScopedFactories(services);
            NotificationServiceCollection.AddScopedFactories(services);
            OperationAttachmentServiceCollection.AddScopedFactories(services);
            AddressServiceCollection.AddScopedFactories(services);
        }

        public static void AddSingletonBusinessFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddSingletonFactories(services);
            AdditionalAccountServiceCollection.AddSingletonFactories(services);
            UIFunctionServiceCollection.AddSingletonFactories(services);
            BankServiceCollection.AddSingletonFactories(services);
            InternalTransferServiceCollection.AddSingletonFactories(services);
            OperationServiceCollection.AddSingletonFactories(services);
            OperationTagServiceCollection.AddSingletonFactories(services);
            BoletoPaymentServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            BankingDataServiceCollection.AddSingletonFactories(services);
            AccountLogServiceCollection.AddSingletonFactories(services);
            CompanyServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            HashCodeServiceCollection.AddSingletonFactories(services);
            CardServiceCollection.AddSingletonFactories(services);
            FavoredServiceCollection.AddSingletonFactories(services);
            TagServiceCollection.AddSingletonFactories(services);
            CardServiceCollection.AddSingletonFactories(services);
            NewAccountServiceCollection.AddSingletonFactories(services);
            LimitedAccountServiceCollection.AddSingletonFactories(services);
            TopUpServiceCollection.AddSingletonFactories(services);
            TaxPaymentServiceCollection.AddSingletonFactories(services);
            ExceptionLogCollection.AddSingletonFactories(services);
            FutureTransactionsServiceCollection.AddSingletonFactories(services);
            PixServiceCollection.AddSingletonFactories(services);
            NotificationServiceCollection.AddSingletonFactories(services);
            OperationAttachmentServiceCollection.AddSingletonFactories(services);
            AddressServiceCollection.AddSingletonFactories(services);
        }
    }
}