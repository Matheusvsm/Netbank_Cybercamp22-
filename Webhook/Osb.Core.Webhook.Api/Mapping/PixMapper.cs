using System;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class PixMapper
    {
        public BusinessService.UpdatePixKeyStatusRequest Map(UpdatePixKeyStatusRequest updatePixKeyStatusRequest)
        {
            return new BusinessService.UpdatePixKeyStatusRequest
            {
                CompanyId = updatePixKeyStatusRequest.BusinessUnitId,
                Bank = updatePixKeyStatusRequest.Bank,
                BankBranch = updatePixKeyStatusRequest.BankBranch,
                BankAccount = updatePixKeyStatusRequest.BankAccount,
                BankAccountDigit = updatePixKeyStatusRequest.BankAccountDigit,
                PixKeyStatus = Enum.Parse<PixKeyStatus>(updatePixKeyStatusRequest.Status),
                PixKey = updatePixKeyStatusRequest.PixKey,
                PixKeyType = Enum.Parse<PixKeyType>(updatePixKeyStatusRequest.Type)
            };
        }

        public BusinessService.PixInRequest Map(PixInRequest pixInRequest)
        {
            return new BusinessService.PixInRequest
            {
                ToBankNumber = pixInRequest.ToBankNumber,
                ToBankAccount = pixInRequest.ToBankAccount,
                ToBankAccountDigit = pixInRequest.ToBankAccountDigit,
                ToBankBranch = pixInRequest.ToBankBranch,
                ToTaxNumber = pixInRequest.ToTaxNumber,
                Value = pixInRequest.Value,
                Status = Enum.Parse<PixOutStatus>(pixInRequest.Status)
            };
        }
        public BusinessService.UpdatePixRequest Map(UpdatePixRequest updatePixOutStatusRequest)
        {
            return new BusinessService.UpdatePixRequest
            {
                ExternalIdentifier = updatePixOutStatusRequest.ExternalIdentifier,
                Status = Enum.Parse<PixOutStatus>(updatePixOutStatusRequest.Status)
            };
        }
    }
}