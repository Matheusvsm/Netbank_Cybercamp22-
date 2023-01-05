using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface ITagService
    {
        FindSuggestionTagListResponse FindSuggestionTagList(FindSuggestionTagListRequest findSuggestionTagsrequest);
    }
}