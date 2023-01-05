using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindInfosPaymentByBarcodeRequest : BaseRequest
    {
        public new string Method { get => "GetInfosByBarcode"; }
        public string Barcode { get; set; }
    }
}