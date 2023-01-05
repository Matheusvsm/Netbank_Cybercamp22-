using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindInfosPixKeyResponse
    {

        [JsonPropertyName("ReceiverName")]
        public string PayeeName { get; set; }

        [JsonPropertyName("ReceiverBank")]
        public string PayeeBank { get; set; }

        [JsonPropertyName("ReceiverBankBranch")]
        public string PayeeBankBranch { get; set; }

        [JsonPropertyName("ReceiverBankAccount")]
        public string PayeeBankAccount { get; set; }

        [JsonPropertyName("ReceiverBankAccountDigit")]
        public string PayeeBankAccountDigit { get; set; }

        [JsonPropertyName("ReceiverAccountType")]
        public string PayeeAccountType { get; set; }

        [JsonPropertyName("PixKeyType")]
        public string PixKeyType { get; set; }

        [JsonPropertyName("PixKeyValue")]
        public string PixKeyValue { get; set; }

        [JsonPropertyName("ReceiverTaxNumber")]
        public string PayeeTaxNumber { get; set; }
    }
}