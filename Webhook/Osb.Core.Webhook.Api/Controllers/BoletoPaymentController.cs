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
    [Route("[controller]/[action]")]
    public class BoletoPaymentController : ControllerBase
    {
        private readonly BoletoPaymentStatusMapper _mapper;
        private readonly IBoletoPaymentServiceFactory _serviceFactory;


        public BoletoPaymentController(IBoletoPaymentServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new BoletoPaymentStatusMapper();
        }

        /// <summary>
        /// Altera o status de um BoletoPayment.
        /// </summary>
        /// <param name="UpdateBoletoPaymentRequest">Body da requisição</param>
        /// <returns>Mudança de status de pagamento por boleto</returns>
        /// <response code="200">Atualizado com sucesso</response>
        /// <response code="400">Não atualizado</response>

        [ValidateCredentialRequestFilter]
        [HttpPost]
        public IActionResult UpdateBoletoPaymentStatus([FromBody] UpdateBoletoPaymentStatusRequest updateBoletoPaymentRequest)
        {
            BusinessService.UpdateBoletoPaymentStatusRequest boletoPaymentRequest = _mapper.Map(updateBoletoPaymentRequest);

            IBoletoPaymentService boletoPaymentService = _serviceFactory.Create();

            boletoPaymentService.UpdateBoletoPaymentStatus(boletoPaymentRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

    }
}