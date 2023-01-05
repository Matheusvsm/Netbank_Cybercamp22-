using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity.Enums;
namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class PixKey
    {
        [JsonPropertyName("PixKey")]
        public string PixKeyValue { get; set; }

        public PixKeyType PixKeyType { get; set; }

        public string Status { get; set; }

        public string Bank { get; set; }

        public string BankBranch { get; set; }

        public string BankAccount { get; set; }

        public string BankAccountDigit { get; set; }
    }
}
