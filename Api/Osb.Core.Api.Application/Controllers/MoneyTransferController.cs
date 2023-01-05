using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        /// Geração de uma TED para outros bancos.
        /// </summary>
        /// <param name="moneyTransferRequest">Body da requisição</param>
        /// <returns>TED para outros bancos.</returns>
        /// <response code="200">Retona confirmação de TED.</response>
        /// <response code="400">TED não concluída.</response>        

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] MoneyTransferRequest moneyTransferRequest)
        {
            BusinessService.MoneyTransferRequest businessRequest = _mapper.Map(moneyTransferRequest);

            IMoneyTransferService moneyTransferService = _serviceFactory.Create();

            OperationResult operationResult = moneyTransferService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult);
            return Ok(response);
        }

        /// <summary>
        /// Busca o proximo dia útil para uma TED.
        /// </summary>
        /// <param name="findExpectedTransferDateRequest">Body da requisição</param>
        /// <returns>Proximo dia útil para uma TED.</returns>
        /// <response code="200">Retona proximo dia útil para uma TED.</response>
        /// <response code="400">TED não encontrada</response>        

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindExpectedTransferDate([FromBody] FindExpectedTransferDateRequest findExpectedTransferDateRequest)
        {
            BusinessService.FindExpectedTransferDateRequest businessRequest = _mapper.Map(findExpectedTransferDateRequest);

            IMoneyTransferService moneyTransferService = _serviceFactory.Create();
            FindExpectedTransferDateResult result = moneyTransferService.FindExpectedTransferDate(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Altera status de MoneyTransfer.
        /// </summary>
        /// <param name="updateMoneyTransferRequest">Body da requisição</param>
        /// <returns>Alteração de status Money Transfer.</returns>
        /// <response code="200">Status alterado com sucesso.</response>
        /// <response code="400">Status não foi alterado.</response>   

        [HttpPut()]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            BusinessService.UpdateMoneyTransferRequest businessRequest = _mapper.Map(updateMoneyTransferRequest);

            IMoneyTransferService moneyTransferService = _serviceFactory.Create();
            moneyTransferService.UpdateStatus(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}