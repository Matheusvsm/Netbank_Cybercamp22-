using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class TagMapper
    {
        public FindSuggestionTagListRequest Map(Models.Request.FindSuggestionTagListRequest request, Account account)
        {
            return new FindSuggestionTagListRequest
            {
                AccountId = request.AccountId,
                TaxId = account.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                TagAmount = request.TagAmount,
                UserId = request.UserId
            };
        }

        public FindSuggestionTagListResult Map(FindSuggestionTagListResponse response)
        {
            return new FindSuggestionTagListResult
            {
                Tags = response.Tags
            };
        }
    }
}