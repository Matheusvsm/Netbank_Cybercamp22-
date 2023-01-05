using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class TopUpMapper
    {
        public BusinessService.UpdateTopUpStatusRequest Map(TopUpWebhookRequest topUpRequest)
        {
            return new BusinessService.UpdateTopUpStatusRequest
            {
                ProductKey = topUpRequest.ProductKey,
                ExternalIdentifier = Int64.Parse(topUpRequest.ExternalIdenfifier),
                TopUpStatus = Enum.Parse<TopUpStatus>(topUpRequest.Status)
            };
        }
    }
}