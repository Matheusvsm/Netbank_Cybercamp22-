using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Microsoft.AspNetCore.Http;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// Salva um dispositivo
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceServiceFactory _serviceFactory;
        private readonly DeviceMapper _mapper;

        public DeviceController(IDeviceServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new DeviceMapper();
        }

        /// <summary>
        /// Salva um device
        /// </summary>
        /// <param name="registerDeviceRequest">Request body</param>
        /// <returns>Device salvo</returns>
        /// <response code="200">Salva um device</response>
        /// <response code="400">Device não salvo</response>

        [HttpPost]
        public IActionResult Post([FromBody] RegisterDeviceRequest registerDeviceRequest)
        {
            RegisterUserDeviceRequest registerUserDeviceRequest = _mapper.Map(registerDeviceRequest, HttpContext.Items["CompanyId"]);

            IDeviceService notificationService = _serviceFactory.Create();
            notificationService.RegisterDevice(registerUserDeviceRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}