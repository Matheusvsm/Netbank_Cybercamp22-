using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Integration.Entity.Models
{
    public class IntegrationLog : BaseEntity
    {
        public long IntegrationLogId { get; set; }
        public string Body { get; set; }
        public string Headers { get; set; }
        public string Url { get; set; }
        public long StatusCode { get; set; }
        public string Response { get; set; }

        public static IntegrationLog Create(string body, string url, string headers, long statusCode, string response, long userId)
        {
            return new IntegrationLog
            {
                Body = body,
                Url = url,
                Headers = headers,
                StatusCode = statusCode,
                Response = response,
                CreationUserId = userId
            };
        }
    }
}