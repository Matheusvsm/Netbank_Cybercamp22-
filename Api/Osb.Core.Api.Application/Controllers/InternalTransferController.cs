using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
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
    public class InternalTransferController : ControllerBase
    {
        private readonly InternalTransferMapper _mapper;
        private readonly IInternalTransferServiceFactory _serviceFactory;

        public InternalTransferController
        (
            IInternalTransferServiceFactory serviceFactory
        )
        {
            _serviceFactory = serviceFactory;
            _mapper = new InternalTransferMapper();
        }

        /// <summary>
        /// Salva uma transferência interna no banco de dados.
        /// </summary>
        /// <param name="internalTransferRequest">Body da requisição</param>
        /// <returns>Confirmação de uma transferência interna bem-sucedida</returns>
        /// <response code="200">Confirmação de uma transferência interna bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] InternalTransferRequest internalTransferRequest)
        {
            BusinessService.InternalTransferRequest businessRequest = _mapper.Map(internalTransferRequest);

            IInternalTransferService internalTransferService = _serviceFactory.Create();

            OperationResult operationResult = internalTransferService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult);
 
            return Ok(response);
        }

        /// <summary>
        /// Altera status de InternalTransfer
        /// </summary>
        /// <param name="updateInternalTransferRequest">Body da requisição</param>
        /// <returns>Alteração de status InternalTransfer.</returns>
        /// <response code="200">Status alterado com sucesso.</response>
        /// <response code="400">Status não foi alterado.</response> 

        [HttpPut()]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] UpdateInternalTransferRequest updateInternalTransferRequest)
        {
            BusinessService.UpdateInternalTransferRequest businessRequest = _mapper.Map(updateInternalTransferRequest);

            IInternalTransferService internalTransferService = _serviceFactory.Create();
            internalTransferService.UpdateStatus(businessRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

        /// <summary>
        /// Busca por transferências internas pendentes
        /// </summary>
        /// <param name="findPendingInternalTransferRequest">Body da requisição</param>
        /// <returns>Busca transferências internas pendentes</returns>
        /// <response code="200">Busca por transferências internas pendentes bem-sucedida</response>
        /// <response code="400">Nenhuma transferência interna pendente encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult FindPendingInternalTransfer([FromBody] FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {
            BusinessService.FindPendingInternalTransferRequest businessRequest = _mapper.Map(findPendingInternalTransferRequest, HttpContext.Items["CompanyId"]);

            IInternalTransferService internalTransferService = _serviceFactory.Create();
            FindPendingInternalTransferResult result = internalTransferService.FindPendingInternalTransfer(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Gera transferencias via SMS
        /// </summary>
        /// <param name="pendingTransferInternalRequest">Body da requisição</param>
        /// <returns>Gera transferencias via SMS</returns>
        /// <response code="200">InternalTransfer gerada com sucesso</response>
        /// <response code="400">Não foi possível gerar a InternalTransfer</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreatePendingInternalTransfer([FromBody] PendingInternalTransferRequest pendingTransferInternalRequest)
        {
            BusinessService.PendingInternalTransferRequest businessRequest = _mapper.Map(pendingTransferInternalRequest);

            IInternalTransferService internalTransferService = _serviceFactory.Create();

            OperationResult operationResult = internalTransferService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult);

            return Ok(response);
        }
    }
}