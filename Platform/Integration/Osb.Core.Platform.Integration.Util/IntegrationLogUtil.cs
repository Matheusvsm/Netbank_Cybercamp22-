using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using System.Text.Json;

namespace Osb.Core.Platform.Integration.Util
{
    public static class IntegrationLogUtil
    {
        public static void SaveLog(ExternalRequest externalRequest, ExternalResponse externalResponse, IIntegrationLogRepositoryFactory integrationRepositoryFactory, long userId)
        {
            IntegrationLog integrationLog = IntegrationLog.Create(
                                                                    externalRequest.Body.ToString(),
                                                                    externalRequest.Url,
                                                                    JsonSerializer.Serialize(externalRequest.Headers),
                                                                    externalResponse.StatusCode,
                                                                    externalResponse.Data,
                                                                    userId
            );

            IIntegrationLogRepository integrationRepository = integrationRepositoryFactory.Create();
            integrationRepository.InsertIntegrationLog(integrationLog);
        }
    }
}