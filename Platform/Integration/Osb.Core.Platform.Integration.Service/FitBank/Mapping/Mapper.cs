using System.Text.Json;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class Mapper
    {
        public T Map<T>(ExternalResponse externalResponse)
        {
            return JsonSerializer.Deserialize<T>(externalResponse.Data);
        }

        public T Map<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}