using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class GenerateStaticPixQRCodeRequest : BaseRequest
    {
        public decimal? PrincipalValue { get; set; }
        public string PixKey { get; set; }
        public PixAddressRequest Address { get; set; }
        public string AdditionalData { get; set; }
        public PixTransactionPurpose? PixTransactionPurpose { get; set; }
        public PixKeyType PixKeyType { get; set; }
    }
}