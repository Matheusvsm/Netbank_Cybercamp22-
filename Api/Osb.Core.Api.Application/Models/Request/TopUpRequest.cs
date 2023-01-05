using System;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class TopUpRequest
    {
        public long TopUpId { get; set; }
        public long AccountId { get; set; }
        public TopUpType? ProductType { get; set; }
        public string BatchIdentifier { get; set; }
        public string ProductKey { get; set; }
        public decimal? ProductValue { get; set; }
        public string ContractIdentifier { get; set; }
        public string OriginNSU { get; set; }
        public long ExternalIdentifier { get; set; }
        public string UrlReceipt { get; set; }
        public TopUpStatus Status { get; set; }
        public long OperationId { get; set; }
        public int Attempts { get; set; }
        public int? PeriodicRepetition { get; set; }
        public DateTime TopUpDate { get; set; }
        public bool IsRecurrent { get; set; }
    }
}