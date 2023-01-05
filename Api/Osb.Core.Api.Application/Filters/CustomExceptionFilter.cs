using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Api.Common;

namespace Osb.Core.Api.Application.Filters
{
    /// <summary>
    /// Classe que faz o tratamento global das exceções da aplicação.
    /// </summary>
    /// <exception cref="ExceptionContext.Exception">Exceção genérica</exception>
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode httpStatusCode;
            var response = new Response();

            switch (context.Exception)
            {
                case OsbApiException:
                case OsbAuthException:
                case OsbBusinessException:
                case OsbIntegrationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.Message = context.Exception.Message;
                    break;

                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    response.Message = "Ocorreu um erro inesperado";
                    break;
            }

            var result = new ObjectResult(response);
            result.StatusCode = (int)httpStatusCode;
            context.Result = result;
        }
    }
}