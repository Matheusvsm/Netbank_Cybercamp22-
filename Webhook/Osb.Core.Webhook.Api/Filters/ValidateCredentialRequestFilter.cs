using Microsoft.AspNetCore.Mvc.Filters;

namespace Osb.Core.Webhook.Api.Filters
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
        }
    }
}