using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LimitedAccountController : ControllerBase
    {
        private readonly LimitedAccountMapper _mapper;
        private readonly ILimitedAccountServiceFactory _serviceFactory;

        public LimitedAccountController(ILimitedAccountServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new LimitedAccountMapper();
        }

        /// <summary>
        /// Cria um nova conta limitada.
        /// </summary>
        /// <param name="limitedAccountRequest">Body da requisição</param>
        /// <returns>Nova conta limitada</returns>
        /// <response code="200">Conta limitada criado com sucesso</response>
        /// <response code="400">Erro na criação de conta limitada</response>

        [ValidateCredentialRequestFilter]
        [HttpPost]
        public IActionResult Post([FromBody] LimitedAccountRequest limitedAccountRequest)
        {
            BusinessService.LimitedAccountRequest businessRequest = _mapper.Map(limitedAccountRequest, HttpContext.Items["CompanyId"]);

            ILimitedAccountService limitedAccountService = _serviceFactory.Create();
            limitedAccountService.Save(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}