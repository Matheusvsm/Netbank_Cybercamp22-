using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class AccountMapper
    {
        public BusinessService.AccountWebhookRequest Map(AccountWebhookRequest accountWebhookRequest)
        {
            return new BusinessService.AccountWebhookRequest
            {
                CompanyId = accountWebhookRequest.BusinessUnitId,
                Name = accountWebhookRequest.Name,
                TaxId = accountWebhookRequest.TaxNumber,
                AccountKey = accountWebhookRequest.AccountKey,
                Bank = accountWebhookRequest.Bank,
                BankBranch = accountWebhookRequest.BankBranch,
                BankAccount = accountWebhookRequest.BankAccount,
                BankAccountDigit = accountWebhookRequest.BankAccountDigit,
                SPBAccount = Map(accountWebhookRequest.SPBAccount),
            };
        }

        public BusinessService.SPBAccount Map(SPBAccount sPBAccount)
        {
            if (sPBAccount != null)
            {
                return new BusinessService.SPBAccount
                {
                    Bank = sPBAccount.Bank,
                    BankBranch = sPBAccount.BankBranch,
                    BankAccount = sPBAccount.BankAccount,
                    BankAccountDigit = sPBAccount.BankAccountDigit
                };
            }

            return null;
        }
    }
}