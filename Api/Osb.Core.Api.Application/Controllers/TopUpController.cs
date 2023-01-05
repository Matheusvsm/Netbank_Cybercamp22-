using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Application.Mapping;
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
    public class TopUpController : ControllerBase
    {
        private readonly TopUpMapper _mapper;
        private readonly ITopUpServiceFactory _serviceFactory;
        public TopUpController(ITopUpServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new TopUpMapper();
        }

        /// <summary>
        /// Busca lista de Produtos.
        /// </summary>
        /// <param name="findTopUpProductListRequest">Body da requisição</param>
        /// <returns>lista de Produtos</returns>
        /// <response code="200">retorna lista de Produtos de acordo com os dados passados.</response>
        /// <response code="400">Produtos não encontrados</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindTopUpProductList([FromBody] FindTopUpProductListRequest findTopUpProductListRequest)
        {
            BusinessService.FindTopUpProductListRequest bussinessRequest = _mapper.Map(findTopUpProductListRequest);

            ITopUpService topUpService = _serviceFactory.Create();
            FindTopUpProductListResult result = topUpService.FindTopUpProductList(bussinessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Salva os dados necessários para um futura recarga no banco de dados.
        /// </summary>
        /// <param name="TopUpRequest">Body da requisição</param>
        /// <returns>Confirmação de uma recarga TopUp bem-sucedida</returns>
        /// <response code="200">Confirmação de uma recarga TopUp bem-sucedida</response>
        /// <response code="400">Erro ao salvar</response>

        [HttpPost()]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] GenerateTopUpRequest TopUpRequest)
        {
            BusinessService.GenerateTopUpRequest businessRequest = _mapper.Map(TopUpRequest);

            ITopUpService TopUpService = _serviceFactory.Create();

            OperationResult operationResult = TopUpService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, operationResult);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindTopUpProductListByPhoneNumber([FromBody] FindTopUpProductListByPhoneNumberRequest topUpByPhoneNumberRequest)
        {
            BusinessService.FindTopUpProductListByPhoneNumberRequest businessRequest = _mapper.Map(topUpByPhoneNumberRequest);

            ITopUpService topUpService = _serviceFactory.Create();
            FindTopUpProductListByPhoneNumberResult result = topUpService.FindTopUpProductListByPhoneNumber(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindTopUpPeriodicList([FromBody] FindTopUpPeriodicListRequest findTopUpPeriodicListRequest)
        {
            BusinessService.FindTopUpPeriodicListRequest businessRequest = _mapper.Map(findTopUpPeriodicListRequest);

            ITopUpService topUpService = _serviceFactory.Create();
            FindTopUpPeriodicListResult result = topUpService.FindTopUpPeriodicList(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CancelTopUpPeriodic(CancelTopUpPeriodicRequest cancelTopUpPeriodicRequest)
        {
            BusinessService.CancelTopUpPeriodicRequest businessRequest = _mapper.Map(cancelTopUpPeriodicRequest);

            ITopUpService topUpService = _serviceFactory.Create();
            topUpService.CancelTopUpPeriodic(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}