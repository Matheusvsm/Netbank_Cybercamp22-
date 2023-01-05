using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class HashCodeMapper
    {
        public IntegrationRequest.GenerateHashCodeRequest Map(Account account, GenerateHashCodeRequest generateHashCodeRequest)
        {
            return new IntegrationRequest.GenerateHashCodeRequest
            {
                AccountId = generateHashCodeRequest.AccountId,
                TaxId = account.TaxId,
                AccountKey = account.AccountKey,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                Identifier = generateHashCodeRequest.Identifier,
                Value = generateHashCodeRequest.Value,
                UserId = generateHashCodeRequest.UserId
            };
        }

        public IntegrationRequest.ReadHashCodeRequest Map(ReadHashCodeRequest readHashCodeRequest)
        {
            return new IntegrationRequest.ReadHashCodeRequest
            {
                AccountId = readHashCodeRequest.AccountId,
                HashCode = readHashCodeRequest.HashCode,
                UserId = readHashCodeRequest.UserId
            };
        }

        public GenerateHashCodeResult Map(GenerateHashCodeResponse response)
        {
            return new GenerateHashCodeResult
            {
                QRCodeBase64 = response.QRCodeBase64
            };
        }

        public ReadHashCodeResult Map(ReadHashCodeResponse response, Account account)
        {
            return new ReadHashCodeResult
            {
                AccountId = account.AccountId,
                AccountTaxId = response.TaxId,
                Name = account.Name,
                Value = response.Value,
                Bank = response.Bank,
                BankBranch = response.BankBranch,
                BankAccount = response.BankAccount,
                BankAccountDigit = response.BankAccountDigit
            };
        }
    }
}