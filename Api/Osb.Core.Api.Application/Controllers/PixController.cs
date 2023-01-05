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
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PixController : ControllerBase
    {

        private readonly IPixServiceFactory _serviceFactory;
        private PixMapper _mapper;
        public PixController(IPixServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new PixMapper();
        }

        /// <summary>
        /// Realiza a criação de uma nova chave Pix.
        /// </summary>
        /// <param name="createPixKeyRequest">Body da requisição</param>
        /// <returns>Chave Pix criada</returns>
        /// <response code="200">Retorna a chave criada</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreatePixKey([FromBody] CreatePixKeyRequest createPixKeyRequest)
        {
            BusinessService.CreatePixKeyRequest businessRequest = _mapper.Map(createPixKeyRequest);

            IPixService pixService = _serviceFactory.Create();
            CreatePixKeyResult result = pixService.CreatePixKey(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }


        /// <summary>
        /// Realiza a confirmação de uma nova chave Pix.
        /// </summary>
        /// <param name="confirmPixKeyHoldRequest">Body da requisição</param>
        /// <returns>Token confirmado</returns>
        /// <response code="200">Token confirmado</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ConfirmPixKeyHold([FromBody] ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest)
        {
            BusinessService.ConfirmPixKeyHoldRequest businessRequest = _mapper.Map(confirmPixKeyHoldRequest);

            IPixService pixService = _serviceFactory.Create();
            ConfirmPixKeyHoldResult result = pixService.ConfirmPixKeyHold(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Realiza o reenvio de token para confirmação de chave.
        /// </summary>
        /// <param name="resendPixKeyToken">Body da requisição</param>
        /// <returns>Token enviado</returns>
        /// <response code="200">Token enviado</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ResendPixKeyToken([FromBody] ResendPixKeyToken resendPixKeyToken)
        {
            BusinessService.ResendPixKeyTokenRequest businessRequest = _mapper.Map(resendPixKeyToken);

            IPixService pixService = _serviceFactory.Create();
            ResendPixKeyTokenResult result = pixService.ResendPixKeyToken(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Realiza a criação de uma nova chave Pix.
        /// </summary>
        /// <param name="cancelPixKeyRequest">Body da requisição</param>
        /// <returns>Chave Pix criada</returns>
        /// <response code="200">Retorna a chave criada</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CancelPixKey([FromBody] CancelPixKeyRequest cancelPixKeyRequest)
        {
            BusinessService.CancelPixKeyRequest businessRequest = _mapper.Map(cancelPixKeyRequest);

            IPixService pixService = _serviceFactory.Create();
            CancelPixKeyResult result = pixService.CancelPixKey(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Realiza a devolução de um pix recebido.
        /// </summary>
        /// <param name="refundPixInRequest">Body da requisição</param>
        /// <returns>Dados da devolução do pix</returns>
        /// <response code="200">Dados da devolução do pix</response>
        /// <response code="400">Ocorreu algum erro</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public IActionResult CreateRefundPixIn([FromBody] RefundPixInRequest refundPixInRequest)
        {
            BusinessService.RefundPixInRequest businessRequest = _mapper.Map(refundPixInRequest);

            IPixService pixService = _serviceFactory.Create();
            OperationResult operationResult = pixService.CreateRefundPixIn(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult);
            return Ok(response);
        }

        /// <summary>
        /// Realiza Listagem de chaves Pix.
        /// </summary>
        /// <param name="findPixKeyListRequest">Body da requisição</param>
        /// <returns>Chave Pix criada</returns>
        /// <response code="200">Retorna a chave criada</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindPixKeyList([FromBody] FindPixKeyListRequest findPixKeyListRequest)
        {
            BusinessService.FindPixKeyListRequest businessRequest = _mapper.Map(findPixKeyListRequest);

            IPixService pixService = _serviceFactory.Create();
            FindPixKeyListResult result = pixService.FindPixKeyList(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Acessa os dados de uma conta que está atrelada a chave informada.
        /// </summary>
        /// <param name="findInfosPixKeyRequest">Body da requisição</param>
        /// <returns>Chave Pix criada</returns>
        /// <response code="200">Retorna a chave criada</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindInfosPixKey([FromBody] FindInfosPixKeyRequest findInfosPixKeyRequest)
        {
            BusinessService.FindInfosPixKeyRequest businessRequest = _mapper.Map(findInfosPixKeyRequest);

            IPixService pixService = _serviceFactory.Create();
            FindInfosPixKeyResult result = pixService.FindInfosPixKey(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Realiza a operação de transferência via pix e pix saque/troco.
        /// </summary>
        /// <param name="generatePixOutRequest">Body da requisição</param>
        /// <returns>Transferência realizada</returns>
        /// <response code="200">Gera a transferência</response>
        /// <response code="400">Ocorreu algum erro</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreatePixOut([FromBody] GeneratePixOutRequest generatePixOutRequest)
        {
            BusinessService.GeneratePixOutRequest businessRequest = _mapper.Map(generatePixOutRequest);

            IPixService pixService = _serviceFactory.Create();
            OperationResult operationResult = pixService.SavePixOut(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult, ApiInfoMsg.ApiInfo0009);
            return Ok(response);
        }

        /// <summary>
        /// Realiza a criação de um QR Code estático para pix.
        /// </summary>
        /// <param name="generateStaticPixQRCodeRequest">Body da requisição</param>
        /// <returns>Registro criado com QR Code nulo</returns>
        /// <response code="200">Retorna o registro criado com o External Identifier</response>
        /// <response code="400">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateStaticPixQRCode([FromBody] GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest)
        {
            BusinessService.GenerateStaticPixQRCodeRequest businessRequest = _mapper.Map(generateStaticPixQRCodeRequest);

            IPixService pixService = _serviceFactory.Create();
            PixQRCodeResult result = pixService.GenerateStaticPixQRCode(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Gera um QrCode dinâmico de pix.
        /// </summary>
        /// <param name="generateDynamicPixQrCodeRequest">Body da requisição</param>
        /// <returns>QrCode dinâmico gerado.</returns>
        /// <response code="200">Retorna o externalIdentifier</response>
        /// <response code="500">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GenerateDynamicPixQrCode([FromBody] GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest)
        {
            BusinessService.GenerateDynamicPixQrCodeRequest businessRequest = _mapper.Map(generateDynamicPixQrCodeRequest);

            IPixService pixService = _serviceFactory.Create();
            pixService.GenerateDynamicPixQrCode(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Busca um QrCode de transferência pix.
        /// </summary>
        /// <param name="findPixQrCodeRequest">Body da requisição</param>
        /// <returns>QrCode.</returns>
        /// <response code="200">Retorna o QrCode</response>
        /// <response code="500">Ocorreu algum erro</response> 

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindPixQrCode([FromBody] FindPixQrCodeRequest findPixQrCodeRequest)
        {
            BusinessService.FindPixQrCodeRequest businessRequest = _mapper.Map(findPixQrCodeRequest);

            IPixService pixService = _serviceFactory.Create();
            PixQRCode pixQrCode = pixService.FindPixQrCode(businessRequest);

            Response response = ResponseMapper.Map(true, pixQrCode);
            return Ok(response);
        }

        /// <summary>
        /// Retorna as informações relacionadas a um QR Code.
        /// </summary>
        /// <param name="findInfoPixQRCodeRequest">Body da requisição</param>
        /// <returns>Dados do QRCode</returns>
        /// <response code="200">Retorna os dados</response>
        /// <response code="400">Ocorreu algum erro</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindInfoPixQRCode([FromBody] FindInfoPixQRCodeRequest findInfoPixQRCodeRequest)
        {
            BusinessService.FindInfoPixQRCodeRequest businessRequest = _mapper.Map(findInfoPixQRCodeRequest);

            IPixService pixService = _serviceFactory.Create();
            FindInfoPixQRCodeResult result = pixService.FindInfoPixQRCode(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}