using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class InternalTransferMapper
    {
        public BusinessService.UpdateInternalTransferRequest Map(UpdateInternalTransferStatusRequest updateinternalTransferStatusRequest)
        {
            return new BusinessService.UpdateInternalTransferRequest
            {
                ExternalIdentifier = updateinternalTransferStatusRequest.ExternalIdentifier,
                Status = Enum.Parse<InternalTransferStatus>(updateinternalTransferStatusRequest.Status)
            };
        }
    }
}