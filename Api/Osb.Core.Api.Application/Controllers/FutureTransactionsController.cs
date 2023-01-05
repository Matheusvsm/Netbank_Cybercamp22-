using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FutureTransactionsController : ControllerBase
    {

        private readonly IFutureTransactionsServiceFactory _serviceFactory;
        private FutureTransactionsMapper _mapper;

        public FutureTransactionsController(IFutureTransactionsServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new FutureTransactionsMapper();
        }

        /// <summary>
        /// Busca uma lista de FutureTransactions
        /// </summary>
        /// <param name="findFutureTransactionsListRequest">Body da requisição</param>
        /// <returns>Lista de FutureTransactions</returns>
        /// <response code="200">Retorna a Lista de FutureTransactions</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindFutureTransactionsList([FromBody] FindFutureTransactionsListRequest findFutureTransactionsListRequest)
        {
            BusinessService.FindFutureTransactionsListRequest businessRequest = _mapper.Map(findFutureTransactionsListRequest);

            IFutureTransactionsService FutureTransactionsService = _serviceFactory.Create();
            FindFutureTransactionsListResult result = FutureTransactionsService.FindFutureTransactionsList(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        // [HttpPost("[action]")]
        // [ValidateCredentialRequestFilter]
        // [TypeFilter(typeof(ValidateUserAccountFilter))]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // public IActionResult FindFuturePaymentsList([FromBody] FindFuturePaymentsListRequest findFuturePaymentsListRequest)
        // {
        //     BusinessService.FindFuturePaymentsListRequest businessRequest = _mapper.Map(findFuturePaymentsListRequest);

        //     IFutureTransactionsService FutureTransactionsService = _serviceFactory.Create();
        //     FindFuturePaymentsListResult result = FutureTransactionsService.FindFuturePaymentsList(businessRequest);

        //     Response response = ResponseMapper.Map(true, result);
        //     return Ok(response);
        // }

        /// <summary>
        /// Cancela uma transação futura.
        /// </summary>
        /// <param name="cancelFuturePaymentRequest">Body da requisição</param>
        /// <returns>Realiza o cancelamento de uma transação.</returns>
        /// <response code="200">Cancela transação</response>
        /// <response code="400">Não foi possivel cancelar a transação</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CancelFuturePayment(CancelFuturePaymentRequest cancelFuturePaymentRequest)
        {
            BusinessService.CancelFuturePaymentRequest businessRequest = _mapper.Map(cancelFuturePaymentRequest);

            IFutureTransactionsService futureTransactionsService = _serviceFactory.Create();
            CancelFuturePaymentResult result = futureTransactionsService.CancelFuturePayment(businessRequest);

            Response response = ResponseMapper.Map(result.Success);

            return Ok(response);
        }
    }
}