using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class GenerateDynamicPixQrCodeRequest : BaseRequest
    {
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public string PayerTaxId { get; set; }
        public string PayerName { get; set; }
        public decimal Value { get; set; }
        public PixAddress Address { get; set; }
        public ChangeType ChangeType { get; set; }
    }
}