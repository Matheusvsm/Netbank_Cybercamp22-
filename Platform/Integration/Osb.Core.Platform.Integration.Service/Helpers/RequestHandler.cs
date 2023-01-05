using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.Helpers
{
    public class RequestHandler
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public ExternalResponse Post(ExternalRequest request)
        {
            if(request.Headers != null)
                SetHeaders(request.Headers);

            string bodyJson = JsonSerializer.Serialize(request.Body);
            HttpResponseMessage responseMessage = _httpClient.PostAsync(
                request.Url,
                new StringContent(bodyJson, Encoding.UTF8, "application/json")
            ).Result;
            string content = responseMessage.Content.ReadAsStringAsync().Result;

            return ExternalResponseMapper.Map(responseMessage.StatusCode, content);
        }

        private void SetHeaders(Headers headers)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                headers.Authorization.Type.ToString(),
                headers.Authorization.Data
            );

            var otherHeaders = headers.Others;
            foreach (var headerName in otherHeaders.Keys)
            {
                _httpClient.DefaultRequestHeaders.Add(headerName, otherHeaders[headerName]);
            }
        }
    }
}