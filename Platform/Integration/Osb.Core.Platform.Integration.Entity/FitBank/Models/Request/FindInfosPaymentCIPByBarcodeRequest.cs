using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindInfosPaymentCIPByBarcodeRequest : BaseRequest
    {
        public new string Method { get => "GetInfosCIPByBarcode"; }
        public string TaxId { get; set; }
        public string BarCode { get; set; }
    }
}