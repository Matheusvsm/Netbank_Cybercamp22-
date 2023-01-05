using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HashCodeController : ControllerBase
    {
        private readonly HashCodeMapper _mapper;
        private readonly IHashCodeServiceFactory _serviceFactory;

        public HashCodeController(IHashCodeServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new HashCodeMapper();
        }

        /// <summary>
        /// Salva um hash code no banco de dados.
        /// </summary>
        /// <param name="generateHashCodeRequest">Body da requisição</param>
        /// <returns>Confirmação da criação de um hash code bem-sucedida</returns>
        /// <response code="200">Confirmação da criação um hash code bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GenerateHashCode([FromBody] GenerateHashCodeRequest generateHashCodeRequest)
        {
            BusinessService.GenerateHashCodeRequest businessRequest = _mapper.Map(generateHashCodeRequest);

            IHashCodeService hashCodeService = _serviceFactory.Create();
            GenerateHashCodeResult result = hashCodeService.GenerateHashCode(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Lê um hash code enviado pelo usuário.
        /// </summary>
        /// <param name="readHashCodeRequest">Body da requisição</param>
        /// <returns>Retorno dos dados associados ao hash code</returns>
        /// <response code="200">Confirmação da leitura de um hash code bem-sucedida e retorno dos dados associados ao hash code</response>
        /// <response code="400">Erro de leitura encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ReadHashCode([FromBody] ReadHashCodeRequest readHashCodeRequest)
        {
            BusinessService.ReadHashCodeRequest businessRequest = _mapper.Map(readHashCodeRequest);

            IHashCodeService hashCodeService = _serviceFactory.Create();
            ReadHashCodeResult result = hashCodeService.ReadHashCode(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }
    }
}