using System.Text.Json.Serialization;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Entity.Response
{
    public class ReadHashCodeResponse : BaseResponse
    {
        public string AccountKey { get; set; }

        [JsonPropertyName("TaxNumber")]
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public decimal Value { get; set; }
    }
}