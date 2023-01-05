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
    public class InternalTransferController : ControllerBase
    {
        private readonly InternalTransferMapper _mapper;
        private readonly IInternalTransferServiceFactory _serviceFactory;

        public InternalTransferController(IInternalTransferServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new InternalTransferMapper();
        }

        /// <summary>
        /// Altera o status de uma InternalTransfer.
        /// </summary>
        /// <param name="updateInternalTransferStatus">Body da requisição</param>
        /// <returns>Mudança de status de InternalTransfer</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Status não alterado</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdateInternalTransferStatus([FromBody] UpdateInternalTransferStatusRequest updateInternalTransferStatusRequest)
        {
            BusinessService.UpdateInternalTransferRequest businessRequest = _mapper.Map(updateInternalTransferStatusRequest);

            IInternalTransferService internalTransferService = _serviceFactory.Create();
            internalTransferService.UpdateStatus(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}