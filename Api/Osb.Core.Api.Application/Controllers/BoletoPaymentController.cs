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

    public class BoletoPaymentController : ControllerBase
    {
        private readonly BoletoPaymentMapper _mapper;
        private readonly IBoletoPaymentServiceFactory _serviceFactory;

        public BoletoPaymentController(IBoletoPaymentServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new BoletoPaymentMapper();
        }

        /// <summary>
        /// Gera um pagamento.
        /// </summary>
        /// <param name="boletoPaymentRequest">Body da requisição</param>
        /// <returns>Saldo da conta</returns>
        /// <response code="200">Gerar pagamento</response>
        /// <response code="400">Não foi possível gerar pagamento</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] BoletoPaymentRequest boletoPaymentRequest)
        {
            BusinessService.BoletoPaymentRequest businessRequest = _mapper.Map(boletoPaymentRequest);

            IBoletoPaymentService boletoPaymentService = _serviceFactory.Create();

            OperationResult operationResult = boletoPaymentService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult, ApiInfoMsg.ApiInfo0006);

            return Ok(response);
        }

        /// <summary>
        /// Busca informações de pagamento por linha digitável ou código de barras
        /// </summary>
        /// <param name="findBoletoInfoRequest">Body da requisição</param>
        /// <returns>Informaçoes para pagamento do boleto</returns>
        /// <response code="200">Informações para pagamento de boleto</response>
        /// <response code="400">Não foi possível buscar informações do boleto</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindBoletoInfo([FromBody] FindBoletoInfoRequest findBoletoInfoRequest)
        {
            BusinessService.FindBoletoInfoRequest businessRequest = _mapper.Map(findBoletoInfoRequest);

            IBoletoPaymentService boletoPayment = _serviceFactory.Create();
            FindBoletoInfoResult findBoletoInfoResult = boletoPayment.FindBoletoInfo(businessRequest);

            Response response = ResponseMapper.Map(true, findBoletoInfoResult);
            return Ok(response);
        }

        /// <summary>
        /// Apresenta a data esperada para pagamento de boleto.
        /// </summary>
        /// <param name="findExpectedBoletoPaymentDateRequest"></param>
        /// <returns>Retorna a data esperada para pagamento de boleto</returns>
        /// <response code="200">Data esperada de pagamento de boleto</response>
        /// <response code="400">Data não apresentada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindExpectedBoletoPaymentDate([FromBody] FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            BusinessService.FindExpectedBoletoPaymentDateRequest request = _mapper.Map(findExpectedBoletoPaymentDateRequest);

            IBoletoPaymentService paymentsService = _serviceFactory.Create();
            FindExpectedBoletoPaymentDateResult findExpectedDateBoletoPaymentResult = paymentsService.FindExpectedBoletoPaymentDate(request);

            Response response = ResponseMapper.Map(true, findExpectedDateBoletoPaymentResult);
            return Ok(response);
        }

        /// <summary>
        /// Recupera chave de licença.
        /// </summary>
        /// <response code="204">Chave retornada.</response>
        /// <response code="400">Não foi possível retornar a chave</response>
        /// <response code="401">Aplicação não autorizada</response>

        [HttpGet("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindScanLicenseKey()
        {
            BusinessService.FindScanLicenseKeyRequest request = _mapper.Map(HttpContext.Items["CompanyId"]);

            IBoletoPaymentService paymentsService = _serviceFactory.Create();
            FindScanLicenseKeyResult findScanLicenseKeyResult = paymentsService.FindScanLicenseKey(request);

            Response.Headers.Add("x-license-key", findScanLicenseKeyResult.LicenseKey);
            return NoContent();
        }
    }
}