using Microsoft.AspNetCore.Mvc.Filters;
using Osb.Core.Api.Common;
using Osb.Core.Api.Common.Resources;

namespace Osb.Core.Api.Application.Filters
{
    /// <summary>
    /// Classe que valida se foram enviados a ApiVersion e Token na requisição.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">Versão da API ou Token não encontrados</exception>
    public class ValidateCredentialRequestFilter : ActionFilterAttribute
    {
        public ValidateCredentialRequestFilter()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["x-api-version"]))
                throw new OsbApiException(ApiExcMsg.ApiExc0001);
        }
    }
}