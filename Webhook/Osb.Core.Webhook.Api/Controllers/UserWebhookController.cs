using Microsoft.AspNetCore.Mvc;
using Osb.Core.Webhook.Api.Filters;
using Osb.Core.Webhook.Api.Mapping;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Api.Models.Response;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Interfaces;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserWebhookController : ControllerBase
    {
        private readonly UserMapper _mapper;
        private readonly IUserServiceFactory _serviceFactory;

        public UserWebhookController(IUserServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new UserMapper();
        }

        /// <summary>
        /// Cria um User.
        /// </summary>
        /// <param name="userWebHookRequest">Body da requisição</param>
        /// <returns>Criação e Atualização de um User</returns>
        /// <response code="200">Retona criação um User especifico</response>
        /// <response code="400">User não criado</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        public IActionResult Post([FromBody] UserWebhookRequest userWebHookRequest)
        {
            AuthService.UserWebhookRequest authRequest = _mapper.Map(userWebHookRequest);

            IUserService userService = _serviceFactory.Create();
            userService.UserWebhookHandler(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}