using System.ComponentModel.DataAnnotations;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindInfosPaymentByBarcodeRequest : BaseRequest
    {
        public string Barcode { get; set; }
    }
}