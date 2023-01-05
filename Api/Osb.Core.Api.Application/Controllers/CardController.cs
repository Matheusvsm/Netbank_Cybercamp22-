using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardMapper _mapper;
        private readonly ICardServiceFactory _serviceFactory;
        public CardController(ICardServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new CardMapper();
        }

        /// <summary>
        /// Verifica se o cartão existe.
        /// </summary>
        /// <param name="verifyCardRequest">Body da requisição</param>
        /// <returns>informações do cartão</returns>
        /// <response code="200">Retorna lista das informações do cartão informado.</response>
        /// <response code="400">Informações não encontrada</response>        
        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        public IActionResult VerifyCard([FromBody] VerifyCardRequest verifyCardRequest)
        {
            BusinessService.VerifyCardRequest businessRequest = _mapper.Map(verifyCardRequest, HttpContext.Items["CompanyId"]);
            ICardService cardService = _serviceFactory.Create();
            bool result = cardService.VerifyCard(businessRequest);
            Response response = ResponseMapper.Map(result);
            return Ok(response);
        }

        /// <summary>
        /// Busca os dados de um cartão através do seu identificador.
        /// </summary>
        /// <param name="findCardRequest">Body da requisição</param>
        /// <returns>informações do cartão</returns>
        /// <response code="200">Retorna lista das informações do cartão informado.</response>
        /// <response code="400">Informações não encontrada</response>        

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindCard([FromBody] FindCardRequest findCardRequest)
        {
            BusinessService.FindCardRequest businessRequest = _mapper.Map(findCardRequest);

            ICardService cardService = _serviceFactory.Create();
            FindCardResult result = cardService.FindCard(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Busca lista de cartões.
        /// </summary>
        /// <param name="findCardListRequest">Body da requisição</param>
        /// <returns>Busca de cartões</returns>
        /// <response code="200">Retorna lista de cartões de acordo com o código passado </response>
        /// <response code="400">Lista não encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindCardList([FromBody] FindCardListRequest findCardListRequest)
        {
            BusinessService.FindCardListRequest businessRequest = _mapper.Map(findCardListRequest);

            ICardService cardService = _serviceFactory.Create();
            FindCardListResult result = cardService.FindCardList(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Realiza a ativação de um cartão.
        /// </summary>
        /// <param name="activateCardRequest">Body da requisição</param>
        /// <returns>Confirmação de uma ativação do cartão</returns>
        /// <response code="200">Confirmação de ativação bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Activate([FromBody] ActivateCardRequest activateCardRequest)
        {
            BusinessService.ActivateCardRequest businessRequest = _mapper.Map(activateCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.Activate(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);

            return Ok(response);
        }

        /// <summary>
        /// Bloqueia o cartão do usuário
        /// </summary>
        /// <param name="blockCardRequest">Body da requisição</param>
        /// <returns>Confirmação do bloqueio do Cartão</returns>
        /// <response code="200">Cartão bloqueado</response>
        /// <response code="400">Não foi possível bloquear o cartão</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Block([FromBody] BlockCardRequest blockCardRequest)
        {
            BusinessService.BlockCardRequest businessRequest = _mapper.Map(blockCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.Block(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Desbloqueia o cartão do usuário
        /// </summary>
        /// <param name="unblockCardRequest">Body da requisição</param>
        /// <returns>Confirmação do desbloqueio do Cartão</returns>
        /// <response code="200">Cartão desbloqueado</response>
        /// <response code="400">Não foi possível desbloquear o cartão</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Unblock([FromBody] UnblockCardRequest unblockCardRequest)
        {
            BusinessService.UnblockCardRequest businessRequest = _mapper.Map(unblockCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.Unblock(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Alteração de pin de cartão.
        /// </summary>
        /// <param name="changePinCardRequest">Body da requisição</param>
        /// <returns>Alteração de pin de cartão.</returns>
        /// <response code="200">Alterado com Sucesso.</response>
        /// <response code="400">Alteração não concluída.</response>        

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangePinCard([FromBody] ChangePinCardRequest changePinCardRequest)
        {
            BusinessService.ChangePinCardRequest businessRequest = _mapper.Map(changePinCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.ChangePin(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Vincula proprietário a um cartão não nominal
        /// </summary>
        /// <param name="bindCardRequest">Body da requisição</param>
        /// <returns>Cartão vinculado</returns>
        /// <response code="200">Cartão vinculado</response>
        /// <response code="400">Não foi possível vincular o cartão</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult BindUnnamedCard([FromBody] BindCardRequest bindCardRequest)
        {
            BusinessService.BindCardRequest businessRequest = _mapper.Map(bindCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.BindUnnamedCard(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Inativa o cartão do usuário e Solicita segunda via
        /// </summary>
        /// <param name="inactivateAndReissueCardRequest">Body da requisição</param>
        /// <returns>Identifier do Cartão</returns>
        /// <response code="200">Cartão inativado</response>
        /// <response code="400">Não foi possível inativar o cartão</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult InactivateAndReissue([FromBody] InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            BusinessService.InactivateAndReissueCardRequest businessRequest = _mapper.Map(inactivateAndReissueCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.InactivateAndReissue(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }

        /// <summary>
        /// Cancela o cartão através do seu identificador.
        /// </summary>
        /// <param name="cancelCardRequest">Body da requisição</param>
        /// <returns>Cancela o cartão através do seu identificador.</returns>
        /// <response code="200">Cartão cancelado.</response>
        /// <response code="400">Informações não encontrada</response>        

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CancelCard([FromBody] CancelCardRequest cancelCardRequest)
        {
            BusinessService.CancelCardRequest businessRequest = _mapper.Map(cancelCardRequest);

            ICardService cardService = _serviceFactory.Create();
            CardResult result = cardService.Cancel(businessRequest);

            Response response = ResponseMapper.Map(result.Status, null, result.Message);
            return Ok(response);
        }
    }
}