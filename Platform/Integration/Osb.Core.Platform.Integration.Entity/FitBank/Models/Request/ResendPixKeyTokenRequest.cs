using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class ResendPixKeyTokenRequest : BaseRequest
    {
        public new string Method { get => "ResendPixKeyToken"; }
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public PixKeyType? PixKeyType { get; set; }

    }
}