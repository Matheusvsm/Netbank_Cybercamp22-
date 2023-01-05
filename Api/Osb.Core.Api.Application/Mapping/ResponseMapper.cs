using Osb.Core.Api.Application.Models.Response;

namespace Osb.Core.Api.Application.Mapping
{
    public class ResponseMapper
    {
        public static Response Map(bool success, dynamic data = null, string message = null)
        {
            return new Response
            {
                Success = success,
                Data = data,
                Message = message
            };
        }
    }
}