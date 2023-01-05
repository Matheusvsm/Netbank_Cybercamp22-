using System.Net;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.Mapping
{
    public static class ExternalResponseMapper
    {
        public static ExternalResponse Map(HttpStatusCode statusCode, string bodyJson)
        {
            return new ExternalResponse
            {
                Data = bodyJson,
                StatusCode = (int)statusCode
            };
        }
    }
}