using Microsoft.AspNetCore.Mvc;
using Osb.Core.Webhook.Api.Filters;
using Osb.Core.Webhook.Api.Mapping;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Api.Models.Response;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TopUpController : ControllerBase
    {
        private readonly TopUpMapper _mapper;
        private readonly ITopUpServiceFactory _serviceFactory;

        public TopUpController(ITopUpServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new TopUpMapper();
        }

        /// <summary>
        /// Atualiza uma recarga.
        /// </summary>
        /// <param name="topUpRequest">Body da requisição</param>
        /// <returns>A recarga pode ser autorizada</returns>
        /// <response code="200">Atualiza uma recarga</response>
        /// <response code="400">Recarga não atualizada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdateTopUpStatus([FromBody] TopUpWebhookRequest topUpWebhookRequest)
        {
            BusinessService.UpdateTopUpStatusRequest topUpWebhook = _mapper.Map(topUpWebhookRequest);

            ITopUpService topUpService = _serviceFactory.Create();
            topUpService.UpdateStatus(topUpWebhook);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }
    }
}