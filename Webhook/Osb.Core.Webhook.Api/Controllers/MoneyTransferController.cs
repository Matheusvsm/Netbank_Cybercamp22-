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
    public class MoneyTransferController : ControllerBase
    {
        private readonly MoneyTransferMapper _mapper;
        private readonly IMoneyTransferServiceFactory _serviceFactory;

        public MoneyTransferController(IMoneyTransferServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new MoneyTransferMapper();
        }

        /// <summary>
        /// Atualiza status da MoneyTransfer.
        /// </summary>
        /// <param name="updateMoneyTransferStatus">Body da requisição</param>
        /// <returns>Atualiza MoneyTransfer</returns>
        /// <response code="200">Retona o status atualizado de uma MoneyTransfer especifico</response>
        /// <response code="400">Status da MoneyTransfero não atualizado</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult UpdateMoneyTransferStatus([FromBody] UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            BusinessService.UpdateMoneyTransferRequest businessRequest = _mapper.Map(updateMoneyTransferRequest);

            IMoneyTransferService moneyTransferService = _serviceFactory.Create();
            moneyTransferService.UpdateStatus(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Cria notificação.
        /// </summary>
        /// <param name="notificationMoneyTransferIn">Body da requisição</param>
        /// <returns>Notificação</returns>
        /// <response code="200">Retorna notificão de transferência recebida</response>
        /// <response code="400">Não possível retorna a notificação</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult NotificationMoneyTransferIn([FromBody] NotificationMoneyTransferInRequest notificationMoneyTransferInRequest)
        {
            BusinessService.NotificationMoneyTransferInRequest businessRequest  = _mapper.Map(notificationMoneyTransferInRequest);

            IMoneyTransferService moneyTransferService = _serviceFactory.Create();
            moneyTransferService.NotificationMoneyTransferIn(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}