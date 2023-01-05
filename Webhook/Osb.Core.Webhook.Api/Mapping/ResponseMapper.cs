using Osb.Core.Webhook.Api.Models.Response;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class ResponseMapper
    {
        public static Response Map(bool success, dynamic data = null, string errorMessage = null)
        {
            return new Response
            {
                Success = success,
                Data = data,
                Message = errorMessage
            };
        }
    }
}