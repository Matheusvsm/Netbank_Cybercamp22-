using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class GenerateTopUpRequest : BaseRequest
    {
        public TopUpType? ProductType { get; set; }
        public string BatchIdentifier { get; set; }
        public string ProductKey { get; set; }
        public decimal? ProductValue { get; set; }
        public string ContractIdentifier { get; set; }
        public string OriginNSU { get; set; }
        public List<string> Tags { get; set; }
        public int? PeriodicRepetition{get; set;}
        public DateTime TopUpDate{get; set;}
        public bool IsRecurrent{get; set;}
    }
}