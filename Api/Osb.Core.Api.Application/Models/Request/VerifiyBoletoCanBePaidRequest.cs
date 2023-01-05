using System.ComponentModel.DataAnnotations;

namespace Osb.Core.Api.Application.Models.Request
{
    public class VerifiyBoletoCanBePaidRequest : BaseRequest
    {
        public string Barcode { get; set; }
    }
}