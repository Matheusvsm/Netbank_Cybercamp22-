using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaxPaymentController : ControllerBase
    {
        private readonly TaxPaymentMapper _mapper;
        private readonly ITaxPaymentServiceFactory _serviceFactory;

        public TaxPaymentController(ITaxPaymentServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new TaxPaymentMapper();
        }

        /// <summary>
        /// Gera um pagamento de FGTS
        /// </summary>
        /// <param name="fgtsPaymentRequest">Body da requisição</param>
        /// <returns>Pagamento gerado!</returns>
        /// <response code="200">Gerar pagamento</response>
        /// <response code="400">Não foi possível gerar pagamento</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateFGTSPayment([FromBody] FGTSPaymentRequest fgtsPaymentRequest)
        {
            BusinessService.FGTSPaymentRequest businessRequest = _mapper.Map(fgtsPaymentRequest);

            ITaxPaymentService taxPaymentService = _serviceFactory.Create();

            OperationResult operationResult = taxPaymentService.SaveFGTSPayment(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult, ApiInfoMsg.ApiInfo0006);
            return Ok(response);
        }

        /// <summary>
        /// Gera um pagamento de DARJ
        /// </summary>
        /// <param name="darjPaymentRequest">Body da requisição</param>
        /// <returns>Pagamento gerado!</returns>
        /// <response code="200">Gerar pagamento</response>
        /// <response code="400">Não foi possível gerar pagamento</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateDARJPayment([FromBody] DARJPaymentRequest darjPaymentRequest)
        {
            BusinessService.DARJPaymentRequest businessRequest = _mapper.Map(darjPaymentRequest);

            ITaxPaymentService taxPaymentService = _serviceFactory.Create();

            OperationResult operationResult = taxPaymentService.SaveDARJPayment(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult, ApiInfoMsg.ApiInfo0006);
            return Ok(response);
        }

        /// <summary>
        /// Gera um pagamento de GARE
        /// </summary>
        /// <param name="garePaymentRequest">Body da requisição</param>
        /// <returns>Pagamento gerado!</returns>
        /// <response code="200">Gerar pagamento</response>
        /// <response code="400">Não foi possível gerar pagamento</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateGAREPayment([FromBody] GAREPaymentRequest garePaymentRequest)
        {
            BusinessService.GAREPaymentRequest businessRequest = _mapper.Map(garePaymentRequest);

            ITaxPaymentService taxPaymentService = _serviceFactory.Create();

            OperationResult operationResult = taxPaymentService.SaveGAREPayment(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult, ApiInfoMsg.ApiInfo0006);
            return Ok(response);
        }
    }
}