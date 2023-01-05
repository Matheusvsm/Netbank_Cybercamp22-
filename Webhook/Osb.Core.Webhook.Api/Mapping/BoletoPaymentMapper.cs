using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class BoletoPaymentStatusMapper
    {
        public BusinessService.UpdateBoletoPaymentStatusRequest Map(UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest)
        {
            return new BusinessService.UpdateBoletoPaymentStatusRequest
            {
                ExternalIdentifier = updateBoletoPaymentStatusRequest.ExternalIdentifier,
                Status = Enum.Parse<BoletoPaymentStatus>(updateBoletoPaymentStatusRequest.Status)
            };
        }

    }
}