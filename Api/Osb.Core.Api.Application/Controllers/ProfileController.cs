using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileMapper _mapper;
        private readonly IProfileServiceFactory _serviceFactory;

        public ProfileController(IProfileServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new ProfileMapper();
        }

        /// <summary>
        /// Cria um perfil para o usuário.
        /// </summary>
        /// <param name="profileRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisição bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisição bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateProfile([FromBody] ProfileRequest profileRequest)
        {
            AuthService.ProfileRequest authRequest = _mapper.Map(profileRequest);

            IProfileService profileService = _serviceFactory.Create();
            Profile result = profileService.Save(authRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Atualiza as informações do perfil do usuário.
        /// </summary>
        /// <param name="profileUpdateRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisição bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisição bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPut("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateProfile([FromBody] ProfileUpdateRequest profileUpdateRequest)
        {
            AuthService.ProfileUpdateRequest authRequest = _mapper.Map(profileUpdateRequest);

            IProfileService profileService = _serviceFactory.Create();
            Profile result = profileService.Update(authRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Deleta o perfil do usuário.
        /// </summary>
        /// <param name="profileDeleteRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisição bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisição bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpDelete("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeleteProfile([FromBody] ProfileDeleteRequest profileDeleteRequest)
        {
            AuthService.ProfileDeleteRequest authRequest = _mapper.Map(profileDeleteRequest);

            IProfileService profileService = _serviceFactory.Create();
            profileService.Delete(authRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

        /// <summary>
        /// Lista os perfis do usuário.
        /// </summary>
        /// <param name="findProfileListRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisição bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisição bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindProfileList([FromBody] FindProfileListRequest findProfileListRequest)
        {
            AuthService.FindProfileListRequest authRequest = _mapper.Map(findProfileListRequest);

            IProfileService profileService = _serviceFactory.Create();
            FindProfileListResult result = profileService.FindProfileList(authRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}