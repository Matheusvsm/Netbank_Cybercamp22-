using Osb.Core.Api.Application.Util;
using Osb.Core.Api.Application.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class FavoredMapper
    {
        public BusinessService.FindFavoredListByAccountIdRequest Map(FindFavoredListByAccountIdRequest findFavoredListByAccountIdRequest)
        {
            return new BusinessService.FindFavoredListByAccountIdRequest
            {
                AccountId = findFavoredListByAccountIdRequest.AccountId,
                UserId = findFavoredListByAccountIdRequest.UserId,
                OperationType = findFavoredListByAccountIdRequest.OperationType
            };
        }

        public BusinessService.FavoredRequest Map(FavoredRequest favoredRequest)
        {
            return new BusinessService.FavoredRequest
            {
                AccountId = favoredRequest.AccountId,
                UserId = favoredRequest.UserId,
                TaxId = Formatter.RemoveMaskFromTaxId(favoredRequest.TaxId),
                Name = favoredRequest.Name,
                Type = favoredRequest.Type,
                BankName = favoredRequest.BankName,
                Bank = favoredRequest.Bank,
                BankBranch = favoredRequest.BankBranch,
                BankAccount = favoredRequest.BankAccount,
                BankAccountDigit = favoredRequest.BankAccountDigit
            };
        }
    }
}