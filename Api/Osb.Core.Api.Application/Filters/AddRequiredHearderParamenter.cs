using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Osb.Core.Api.Application.Filters
{
    public class AddRequiredHearderParamenter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters = new List<OpenApiParameter>
            {
                new OpenApiParameter
                {
                    Name = "x-api-version",
                    In = ParameterLocation.Header,
                    Required = true,
                    Description = "Versão da API"
                },
                new OpenApiParameter
                {
                    Name = "x-application-token",
                    In = ParameterLocation.Header,
                    Required = true,
                    Description = "JWT gerado com as chaves da Application (Key e Secret)"
                },
                new OpenApiParameter
                {
                    Name = "x-application-key",
                    In = ParameterLocation.Header,
                    Required = true,
                    Description = "Key da Application"
                },
            };
        }
    }
}