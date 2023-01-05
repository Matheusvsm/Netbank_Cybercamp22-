using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FavoredController : ControllerBase
    {
        private readonly IFavoredServiceFactory _serviceFactory;
        private readonly FavoredMapper _mapper;

        public FavoredController(IFavoredServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new FavoredMapper();
        }

        /// <summary>
        /// Insere favorecidos 
        /// </summary>
        /// <param name="favoredRequest">Request body</param>
        /// <returns>Credenciais</returns>
        /// <response code="200">Insere um favorecido</response>
        /// <response code="400">Favorecido não inserido</response>

        [ValidateCredentialRequestFilter]
        [HttpPost]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] FavoredRequest favoredRequest)
        {
            BusinessService.FavoredRequest businessRequest = _mapper.Map(favoredRequest);

            IFavoredService favoredService = _serviceFactory.Create();
            favoredService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0007);
            return Ok(response);
        }

        /// <summary>
        /// Busca listagem de favorecidos 
        /// </summary>
        /// <param name="findFavoredListByAccountIdRequest">Request body</param>
        /// <returns>Credenciais</returns>
        /// <response code="200">Retorna lista de favorecidos</response>
        /// <response code="400">Não há favorecidos</response>

        [ValidateCredentialRequestFilter]
        [HttpPost]
        [Route("[action]")]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindFavoredListByAccountIdAndOperationType([FromBody] FindFavoredListByAccountIdRequest findFavoredListByAccountIdRequest)
        {
            BusinessService.FindFavoredListByAccountIdRequest businessRequest = _mapper.Map(findFavoredListByAccountIdRequest);

            IFavoredService favoredService = _serviceFactory.Create();
            FindFavoredListResult result = favoredService.FindFavoredListByAccountIdAndOperationType(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}