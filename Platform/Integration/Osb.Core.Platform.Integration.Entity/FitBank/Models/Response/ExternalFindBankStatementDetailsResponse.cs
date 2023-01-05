using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindBankStatementDetailsResponse : BaseResponse
    {
        [JsonPropertyName("Transferencia")]
        public string MoneyTransfer { get; set; }

        [JsonPropertyName("InternalTransfer")]
        public string InternalTransfer { get; set; }

        [JsonPropertyName("Titulo")]
        public string BoletoPayment { get; set; }

        [JsonPropertyName("GARE")]
        public string GAREPayment { get; set; }

        [JsonPropertyName("FGTS")]
        public string FGTSPayment { get; set; }

        [JsonPropertyName("DARJ")]
        public string DARJPayment { get; set; }

        [JsonPropertyName("Info")]
        public string TopUp { get; set; }

        [JsonPropertyName("Infos")]
        public FindPixDetailsResponse PixTransfer { get; set; }
    }
}