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
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressMapper _mapper;

        private readonly IAddressServiceFactory _serviceFactory;

        public AddressController(IAddressServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new AddressMapper();
        }

        /// <summary>
        /// Busca um endereço a partir de um ZipCode/CEP.
        /// </summary>
        /// <param name="findAddressByZipCodeRequest">Body da requisição</param>
        /// <returns>TED para outros bancos.</returns>
        /// <response code="200">Retorna o CEP com todas as informações </response>
        /// <response code="400">CEP não encontrado</response> 
        
        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindAddressByZipCode([FromBody] FindAddressByZipCodeRequest findAddressByZipCodeRequest)
        {
            BusinessService.FindAddressByZipCodeRequest businessRequest = _mapper.Map(findAddressByZipCodeRequest);

            IAddressService addressService = _serviceFactory.Create();
            FindAddressByZipCodeResult result = addressService.FindAddresByZipCode(businessRequest);
            
            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}