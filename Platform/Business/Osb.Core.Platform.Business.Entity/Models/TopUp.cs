using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class TopUp : BaseEntity
    {
        public long? TopUpId { get; set; }
        public long AccountId { get; set; }
        public TopUpType? ProductType { get; set; }
        public string BatchIdentifier { get; set; }
        public string ProductKey { get; set; }
        public decimal? ProductValue { get; set; }
        public string ContractIdentifier { get; set; }
        public string OriginNSU { get; set; }
        public long ExternalIdentifier { get; set; }
        public string UrlReceipt { get; set; }
        public TopUpStatus? Status { get; set; }
        public long OperationId { get; set; }
        public int Attempts { get; set; }
        public int? PeriodicRepetition { get; set; }
        public DateTime TopUpDate { get; set; }
        public bool IsRecurrent { get; set; }
        public static TopUp Create(long accountId, long userId, TopUpType? productType, string batchIdentifier, string productKey, decimal? productValue, string contractIdentifier, string originNSU, long operationId, int? periodicRepetition, DateTime topUpDate, bool isRecurrent, TopUpStatus? status = null, long? topUpId = null)
        {
            return new TopUp
            {
                TopUpId = topUpId,
                AccountId = accountId,
                CreationUserId = userId,
                UpdateUserId = userId,
                ProductType = productType,
                BatchIdentifier = batchIdentifier,
                ProductKey = productKey,
                ProductValue = productValue,
                ContractIdentifier = contractIdentifier,
                OriginNSU = originNSU,
                OperationId = operationId,
                Status = status ?? TopUpStatus.Created,
                PeriodicRepetition = periodicRepetition,
                TopUpDate = topUpDate,
                IsRecurrent = isRecurrent
            };
        }
    }
}