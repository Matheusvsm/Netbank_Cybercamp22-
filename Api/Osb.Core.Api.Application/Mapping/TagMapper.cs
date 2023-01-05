using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Api.Application.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class TagMapper
    {
        public BusinessRequest.FindSuggestionTagListRequest Map(FindSuggestionTagListRequest findSuggestionTagListRequest)
        {
             return new BusinessRequest.FindSuggestionTagListRequest
             {
                 AccountId = findSuggestionTagListRequest.AccountId,
                 UserId = findSuggestionTagListRequest.UserId,
                 TagAmount = findSuggestionTagListRequest.TagAmount
             };
        }
    }
}