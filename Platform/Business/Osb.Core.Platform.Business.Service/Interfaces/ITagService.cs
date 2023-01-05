using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Retorna as Sugestões de Tags
        /// </summary>
        /// <param name="findSuggestionTagsRequest">Body da requisição</param>
        /// <returns>Lista de Tags sugeridas </returns>
        FindSuggestionTagListResult FindSuggestionTagList(FindSuggestionTagListRequest findSuggestionTagsRequest);
    }
}