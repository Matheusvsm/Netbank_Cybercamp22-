using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using System.Linq;
using System.Collections.Generic;

namespace Osb.Core.Api.Application.Mapping
{
    public class TopUpMapper
    {
        public BusinessRequest.FindTopUpProductListRequest Map(FindTopUpProductListRequest findTopUpProductListRequest)
        {
            return new BusinessRequest.FindTopUpProductListRequest
            {
                AccountId = findTopUpProductListRequest.AccountId,
                ProductType = findTopUpProductListRequest.ProductType,
                ProductSubType = findTopUpProductListRequest.ProductSubType,
                ProductValue = findTopUpProductListRequest.ProductValue,
                UserId = findTopUpProductListRequest.UserId
            };
        }

        public BusinessRequest.CancelTopUpPeriodicRequest Map(CancelTopUpPeriodicRequest cancelTopUpPeriodicRequest)
        {

            return new BusinessRequest.CancelTopUpPeriodicRequest
            {
                AccountId = cancelTopUpPeriodicRequest.AccountId,
                UserId = cancelTopUpPeriodicRequest.UserId,
                TopUps = cancelTopUpPeriodicRequest.TopUps.Select(x => new BusinessRequest.TopUpRequest
                {
                    AccountId = x.AccountId,
                    TopUpId = x.TopUpId,
                    ProductType = x.ProductType,
                    BatchIdentifier = x.BatchIdentifier,
                    ProductKey = x.ProductKey,
                    ProductValue = x.ProductValue,
                    ContractIdentifier = x.ContractIdentifier,
                    OriginNSU = x.OriginNSU,
                    ExternalIdentifier = x.ExternalIdentifier,
                    UrlReceipt = x.UrlReceipt,
                    Status = x.Status,
                    OperationId = x.OperationId,
                    Attempts = x.Attempts,
                    PeriodicRepetition = x.PeriodicRepetition,
                    TopUpDate = x.TopUpDate,
                    IsRecurrent = x.IsRecurrent
                })
            };
        }
        public BusinessRequest.FindTopUpPeriodicListRequest Map(FindTopUpPeriodicListRequest findTopUpPeriodicListRequest)
        {
            return new BusinessRequest.FindTopUpPeriodicListRequest
            {
                AccountId = findTopUpPeriodicListRequest.AccountId,
            };
        }

        public BusinessRequest.GenerateTopUpRequest Map(GenerateTopUpRequest topUpRequest)
        {
            return new BusinessRequest.GenerateTopUpRequest
            {
                UserId = topUpRequest.UserId,
                AccountId = topUpRequest.AccountId,
                ProductType = topUpRequest.ProductType,
                BatchIdentifier = topUpRequest.BatchIdentifier,
                ProductKey = topUpRequest.ProductKey,
                ProductValue = topUpRequest.ProductValue,
                ContractIdentifier = Formatter.RemoveMaskFromPhoneNumber(topUpRequest.ContractIdentifier),
                OriginNSU = topUpRequest.OriginNSU,
                Tags = topUpRequest.Tags,
                PeriodicRepetition = topUpRequest.PeriodicRepetition,
                TopUpDate = topUpRequest.TopUpDate,
                IsRecurrent = topUpRequest.IsRecurrent
            };
        }
        public BusinessRequest.FindTopUpProductListByPhoneNumberRequest Map(FindTopUpProductListByPhoneNumberRequest findTopUpProductListByPhoneNumberRequest)
        {
            return new BusinessRequest.FindTopUpProductListByPhoneNumberRequest
            {
                AccountId = findTopUpProductListByPhoneNumberRequest.AccountId,
                UserId = findTopUpProductListByPhoneNumberRequest.UserId,
                PhoneNumber = Formatter.RemoveMaskFromPhoneNumber(findTopUpProductListByPhoneNumberRequest.PhoneNumber),
                ProductSubType = findTopUpProductListByPhoneNumberRequest.ProductSubType
            };
        }
    }
}