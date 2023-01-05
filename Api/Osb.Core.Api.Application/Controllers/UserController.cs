using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Result;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserInformationMapper _mapper;
        private readonly IUserServiceFactory _serviceFactory;

        public UserController(IUserServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new UserInformationMapper();
        }

        /// <summary>
        /// Salva as informações do usuário.
        /// </summary>
        /// <param name="userInformationRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateUserInformation([FromBody] UserInformationRequest userInformationRequest)
        {
            AuthService.UserInformationRequest authRequest = _mapper.Map(userInformationRequest);

            IUserService userService = _serviceFactory.Create();
            userService.SaveUserInformation(authRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

        /// <summary>
        /// Retorna as informações do usuário.
        /// </summary>
        /// <param name="findUserInformationRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindUserInformation([FromBody] FindUserInformationRequest findUserInformationRequest)
        {
            AuthService.FindUserInformationRequest authRequest = _mapper.Map(findUserInformationRequest);

            IUserService userService = _serviceFactory.Create();
            UserInformationResult result = userService.FindUserInformation(authRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza as informações do usuário.
        /// </summary>
        /// <param name="updateUserInformationRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateUserInformation([FromBody] UserInformationRequest updateUserInformationRequest)
        {
            AuthService.UserInformationRequest authRequest = _mapper.Map(updateUserInformationRequest);

            IUserService userService = _serviceFactory.Create();
            userService.UpdateUserInformation(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza a senha do usuário.
        /// </summary>
        /// <param name="changePasswordRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisição bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisição bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            AuthService.ChangePasswordRequest authRequest = _mapper.Map(changePasswordRequest);

            IUserService userService = _serviceFactory.Create();
            userService.ChangePassword(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        // /// <summary>
        // /// Retorna as informações do usuário pelo login.
        // /// </summary>
        // /// <param name="findUserContactsByLoginRequest">Body da requisição</param>
        // /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        // /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        // /// <response code="400">Erro de validação encontrada</response>

        // [HttpPost("[action]")]
        // [ValidateCredentialRequestFilter]
        // public IActionResult FindUserContactsByLogin([FromBody] FindUserContactsByLoginRequest findUserContactsByLoginRequest)
        // {
        //     AuthService.FindUserContactsByLoginRequest authRequest = _mapper.Map(findUserContactsByLoginRequest);

        //     IUserService userService = _serviceFactory.Create();
        //     UserContactsResult result = userService.FindUserContactsByLogin(authRequest);

        //     Response response = ResponseMapper.Map(true, result);
        //     return Ok(response);
        // }

        /// <summary>
        /// Envia uma mensagem de SMS ou E-Mail ao usuário com uma nova senha randômica.
        /// </summary>
        /// <param name="resetPasswordRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            AuthService.ResetPasswordRequest authRequest = _mapper.Map(resetPasswordRequest, HttpContext.Items["CompanyId"]);

            IUserService userService = _serviceFactory.Create();
            userService.ResetPassword(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza o status dos Termos de uso no banco de dados.
        /// </summary>
        /// <param name="updateUserTermsRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdateUserTerms([FromBody] UpdateUserTermsRequest updateUserTermsRequest)
        {
            AuthService.UpdateUserTermsRequest authRequest = _mapper.Map(updateUserTermsRequest, HttpContext.Items["CompanyId"]);

            IUserService userService = _serviceFactory.Create();
            userService.UpdateUserTerms(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}