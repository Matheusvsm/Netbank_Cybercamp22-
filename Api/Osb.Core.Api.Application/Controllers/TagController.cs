using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {

        private readonly ITagServiceFactory _serviceFactory;
        private TagMapper _mapper;

        public TagController(ITagServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new TagMapper();
        }

        /// <summary>
        /// Busca uma lista de sugestão de Tags
        /// </summary>
        /// <param name="findSuggestionTagListRequest">Body da requisição</param>
        /// <returns>Lista de Tags</returns>
        /// <response code="200">Retorna a Lista de Tags</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindSuggestionTagList(FindSuggestionTagListRequest findSuggestionTagListRequest)
        {
            BusinessService.FindSuggestionTagListRequest businessRequest = _mapper.Map(findSuggestionTagListRequest);

            ITagService tagService = _serviceFactory.Create();
            FindSuggestionTagListResult result = tagService.FindSuggestionTagList(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}