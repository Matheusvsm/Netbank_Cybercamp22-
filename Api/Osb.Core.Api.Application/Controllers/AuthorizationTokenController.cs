using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Interfaces;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationTokenController : ControllerBase
    {
        private readonly AuthorizationTokenMapper _mapper;
        private readonly IAuthorizationTokenServiceFactory _serviceFactory;

        public AuthorizationTokenController(IAuthorizationTokenServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new AuthorizationTokenMapper();
        }

        /// <summary>
        /// Gera um token 
        /// </summary>
        /// <param name="generateAuthorizationTokenRequest">Id da Account</param>
        /// <returns>Token</returns>
        /// <response code="200">Gera um token</response>
        /// <response code="400">Não foi possível gerar o token</response>

        [HttpPost("")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        public IActionResult Post([FromBody] GenerateAuthorizationTokenRequest generateAuthorizationTokenRequest)
        {
            AuthService.GenerateAuthorizationTokenRequest generateAuthorizationTokenServiceRequest = _mapper.Map(generateAuthorizationTokenRequest, HttpContext.Items["CompanyId"]);

            IAuthorizationTokenService generateTokenService = _serviceFactory.Create();
            generateTokenService.GenerateAuthorizationToken(generateAuthorizationTokenServiceRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0002);
            return Ok(response);
        }

        /// <summary>
        /// Gera um token 
        /// </summary>        
        /// <returns>Token</returns>
        /// <response code="200">Gera um token</response>
        /// <response code="400">Não foi possível gerar o token</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult GenerateUnauthenticatedAuthorizationToken([FromBody] GenerateAuthorizationTokenRequest authorizationToken)
        {
            AuthService.GenerateAuthorizationTokenRequest authRequest = _mapper.Map(authorizationToken, HttpContext.Items["CompanyId"]);

            IAuthorizationTokenService authorizationTokenService = _serviceFactory.Create();
            authorizationTokenService.GenerateUnauthenticatedAuthorizationToken(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        public IActionResult ValidateAuthorizationToken([FromBody] ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            AuthService.ValidateAuthorizationTokenRequest validateAuthorizationTokenServiceRequest = _mapper.Map(validateAuthorizationTokenRequest);

            IAuthorizationTokenService validateAuthorizationTokenService = _serviceFactory.Create();
            validateAuthorizationTokenService.ValidateAuthorizationToken(validateAuthorizationTokenServiceRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0005);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult ValidateUnauthenticatedAuthorizationToken([FromBody] ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            AuthService.ValidateAuthorizationTokenRequest authRequest = _mapper.Map(validateAuthorizationTokenRequest);

            IAuthorizationTokenService validateAuthorizationTokenService = _serviceFactory.Create();
            validateAuthorizationTokenService.ValidateAuthorizationToken(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}