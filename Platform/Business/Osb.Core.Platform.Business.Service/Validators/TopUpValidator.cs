using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.TopUpExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class TopUpValidator
    {
        public void Validate(FindTopUpProductListRequest findTopUpProductListRequest)
        {
            if (findTopUpProductListRequest.ProductType > TopUpType.TV || findTopUpProductListRequest.ProductType < TopUpType.Phone)
                throw new OsbBusinessException(TopUpExcMsg.EXC0001);

            if (findTopUpProductListRequest.ProductSubType > TopUpProductSubType.DDD99 || findTopUpProductListRequest.ProductSubType < TopUpProductSubType.DDD11)
                throw new OsbBusinessException(TopUpExcMsg.EXC0002);

            if (findTopUpProductListRequest.ProductValue < 0)
                throw new OsbBusinessException(TopUpExcMsg.EXC0003);
        }

        public void Validate(GenerateTopUpRequest topUpRequest)
        {
            if (topUpRequest.ProductType == null || !Enum.IsDefined<TopUpType>((TopUpType)topUpRequest.ProductType))
                throw new OsbBusinessException(TopUpExcMsg.EXC0004);

            if (string.IsNullOrEmpty(topUpRequest.BatchIdentifier))
                throw new OsbBusinessException(TopUpExcMsg.EXC0005);

            if (string.IsNullOrEmpty(topUpRequest.ProductKey))
                throw new OsbBusinessException(TopUpExcMsg.EXC0006);

            if (string.IsNullOrEmpty(topUpRequest.ContractIdentifier))
                throw new OsbBusinessException(TopUpExcMsg.EXC0007);

            if (string.IsNullOrEmpty(topUpRequest.OriginNSU))
                throw new OsbBusinessException(TopUpExcMsg.EXC0008);

            if (topUpRequest.ProductValue == null || topUpRequest.ProductValue <= 0)
                throw new OsbBusinessException(TopUpExcMsg.EXC0009);
        }
        public void Validate(FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest)
        {
            if (findTopUpByPhoneNumberRequest.ProductSubType > TopUpProductSubType.DDD99 || findTopUpByPhoneNumberRequest.ProductSubType < TopUpProductSubType.DDD11)
                throw new OsbBusinessException(TopUpExcMsg.EXC0002);

            if (string.IsNullOrEmpty(findTopUpByPhoneNumberRequest.PhoneNumber))
                throw new OsbBusinessException(TopUpExcMsg.EXC0010);
        }
    }
}