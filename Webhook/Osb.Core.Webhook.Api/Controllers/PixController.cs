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
    public class PixController : ControllerBase
    {
        private readonly PixMapper _mapper;
        private readonly IPixServiceFactory _serviceFactory;

        public PixController(IPixServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new PixMapper();
        }

        /// <summary>
        /// Altera o status de um PixKey.
        /// </summary>
        /// <param name="UpdatePixKeyRequest">Body da requisição</param>
        /// <returns>Mudança de status de chave pix</returns>
        /// <response code="200">Atualizado com sucesso</response>
        /// <response code="400">Não atualizado</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdatePixKey([FromBody] UpdatePixKeyStatusRequest updatePixKeyStatusRequest)
        {
            BusinessService.UpdatePixKeyStatusRequest pixKeyStatusRequest = _mapper.Map(updatePixKeyStatusRequest);

            IPixService pixService = _serviceFactory.Create();

            pixService.UpdatePixKeyStatus(pixKeyStatusRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult NotificationPixIn([FromBody] PixInRequest pixInRequest)
        {
            BusinessService.PixInRequest businessRequest = _mapper.Map(pixInRequest);

            _serviceFactory.Create().NotificationPixIn(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza status da PixOut.
        /// </summary>
        /// <param name="updatePixOutStatus">Body da requisição</param>
        /// <returns>Atualiza PixOut</returns>
        /// <response code="200">Retona o status atualizado de uma PixOut especifico</response>
        /// <response code="400">Status da PixOut não atualizado</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdatePixOutStatus([FromBody] UpdatePixRequest updatePixOutRequest)
        {
            BusinessService.UpdatePixRequest businessRequest = _mapper.Map(updatePixOutRequest);

            IPixService pixService = _serviceFactory.Create();
            pixService.UpdateStatus(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}