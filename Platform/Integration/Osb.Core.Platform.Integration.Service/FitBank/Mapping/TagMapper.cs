using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class TagMapper : Mapper
    {
        public ExternalRequest Map(
           FindSuggestionTagListRequest findSuggestionTagsRequest,
           CompanyAuthentication companyAuthentication)
        {

            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findSuggestionTagsRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findSuggestionTagsRequest.Method,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    TaxNumber = findSuggestionTagsRequest.TaxId,
                    Bank = findSuggestionTagsRequest.Bank,
                    BankBranch = findSuggestionTagsRequest.BankBranch,
                    BankAccount = findSuggestionTagsRequest.BankAccount,
                    BankAccountDigit = findSuggestionTagsRequest.BankAccountDigit,
                    TagAmount = findSuggestionTagsRequest.TagAmount
                }
            };
        }

        public FindSuggestionTagListResponse Map(List<string> tags)
        {
            return new FindSuggestionTagListResponse
            {
                Tags = tags
            };
        }
    }
}