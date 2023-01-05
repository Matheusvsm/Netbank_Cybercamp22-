using System.Collections.Generic;
using System.Linq;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class TopUpMapper : Mapper
    {
        public IntegrationRequest.FindTopUpProductListRequest Map(FindTopUpProductListRequest findTopUpProductsRequest)
        {
            return new IntegrationRequest.FindTopUpProductListRequest
            {
                AccountId = findTopUpProductsRequest.AccountId,
                ProductType = findTopUpProductsRequest.ProductType,
                ProductSubType = findTopUpProductsRequest.ProductSubType,
                ProductValue = findTopUpProductsRequest.ProductValue,
                UserId = findTopUpProductsRequest.UserId
            };
        }
        public FindTopUpPeriodicListResult Map(IEnumerable<TopUp> topUps)
        {
            return new FindTopUpPeriodicListResult
            {
                TopUpPeriodicList = (List<TopUp>)topUps
            };
        }
        public FindTopUpProductListResult Map(FindTopUpProductListResponse response)
        {
            return new FindTopUpProductListResult
            {
                OriginNSU = response.OriginNSU,
                Products = response.Products.Select(x => new TopUpProduct
                {
                    ProductKey = x.ProductKey,
                    BatchIdentifier = x.BatchIdentifier,
                    ProductType = x.ProductType,
                    ProductSubType = x.ProductSubType,
                    ProductValueType = x.ProductValueType,
                    ProductValue = x.ProductValue,
                    ProductMinValue = x.ProductMinValue,
                    ProductMaxValue = x.ProductMaxValue,
                    Description = x.Description
                })
            };
        }

        public IntegrationRequest.TopUpAuthorizeRequest Map(TopUp request)
        {
            return new IntegrationRequest.TopUpAuthorizeRequest
            {
                AccountId = request.AccountId,
                ExternalIdentifier = request.ExternalIdentifier,
                OriginNSU = request.OriginNSU
            };
        }

        public IntegrationRequest.GenerateTopUpRequest Map(TopUp topUp, Account account, IEnumerable<OperationTag> operationTags)
        {
            IntegrationRequest.GenerateTopUpRequest topUpRequest = new IntegrationRequest.GenerateTopUpRequest()
            {
                AccountId = topUp.AccountId,
                TaxNumber = account.TaxId,
                FromBank = account.Bank,
                FromBankBranch = account.BankBranch,
                FromBankAccount = account.BankAccount,
                FromBankAccountDigit = account.BankAccountDigit,
                ProductType = topUp.ProductType,
                BatchIdentifier = topUp.BatchIdentifier,
                ProductKey = topUp.ProductKey,
                ProductValue = topUp.ProductValue,
                ContractIdentifier = topUp.ContractIdentifier,
                OriginNSU = topUp.OriginNSU,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList(),
                PeriodicRepetition = topUp.PeriodicRepetition,
                TopUpDate = topUp.TopUpDate,
                IsRecurrent = topUp.IsRecurrent,
                UserId = topUp.CreationUserId
            };

            return topUpRequest;
        }
        public IntegrationRequest.FindTopUpProductListByPhoneNumberRequest Map(FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest)
        {
            return new IntegrationRequest.FindTopUpProductListByPhoneNumberRequest
            {
                ProductSubType = findTopUpByPhoneNumberRequest.ProductSubType,
                PhoneNumber = findTopUpByPhoneNumberRequest.PhoneNumber,
                AccountId = findTopUpByPhoneNumberRequest.AccountId,
                UserId = findTopUpByPhoneNumberRequest.UserId
            };
        }

        public FindTopUpProductListByPhoneNumberResult Map(FindTopUpProductListByPhoneNumberResponse findTopUpListByPhoneNumberResponse)
        {
            return new FindTopUpProductListByPhoneNumberResult
            {
                OriginNSU = findTopUpListByPhoneNumberResponse.OriginNSU,
                TopUpPhoneNumberList = findTopUpListByPhoneNumberResponse.Products.Select(x => new TopUpProduct
                {
                    ProductKey = x.ProductKey,
                    BatchIdentifier = x.BatchIdentifier,
                    ProductType = x.ProductType,
                    ProductSubType = x.ProductSubType,
                    ProductValueType = x.ProductValueType,
                    ProductValue = x.ProductValue,
                    ProductMinValue = x.ProductMinValue,
                    ProductMaxValue = x.ProductMaxValue,
                    Description = x.Description
                })
            };
        }


    }
}