using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
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
    [Route("[controller]/[action]")]
    public class BankController : ControllerBase
    {
        private readonly BankMapper _mapper;
        private readonly IBankServiceFactory _serviceFactory;
        public BankController(IBankServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new BankMapper();
        }

        /// <summary>
        /// Busca lista de bancos.
        /// </summary>
        /// <param name="findBanksRequest">Body da requisição</param>
        /// <returns>lista de bancos</returns>
        /// <response code="200">retorna lista de bancos de acordo com o código passado.</response>
        /// <response code="400">Lista não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        public IActionResult FindBanks([FromBody] FindBanksRequest findBanksRequest)
        {
            BusinessService.FindBanksRequest businessRequest = _mapper.Map(findBanksRequest);

            IBankService bankService = _serviceFactory.Create();
            FindBanksResult result = bankService.FindBanks(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}