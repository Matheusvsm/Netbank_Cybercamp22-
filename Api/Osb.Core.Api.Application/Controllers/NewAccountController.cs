using Microsoft.AspNetCore.Authorization;
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
    public class NewAccountController : ControllerBase
    {
        private readonly NewAccountMapper _mapper;
        private readonly INewAccountServiceFactory _serviceFactory;

        public NewAccountController(INewAccountServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new NewAccountMapper();
        }

        /// <summary>
        /// Criar nova conta de usuário.
        /// </summary>
        /// <param name="newAccountRequest">Body da requisição</param>
        /// <returns>Conta criada</returns>
        /// <response code="200">Retona com a conta nova </response>
        /// <response code="400">Conta não foi criada</response>
        
        [ValidateCredentialRequestFilter]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] NewAccountRequest newAccountRequest)
        {
            BusinessService.NewAccountRequest businessRequest = _mapper.Map(newAccountRequest, HttpContext.Items["CompanyId"]);

            INewAccountService newAccountService = _serviceFactory.Create();
            newAccountService.Save(businessRequest);
        
            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}