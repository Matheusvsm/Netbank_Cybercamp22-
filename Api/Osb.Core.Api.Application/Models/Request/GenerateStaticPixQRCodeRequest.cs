using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class GenerateStaticPixQRCodeRequest : BaseRequest
    {
        public decimal? PrincipalValue { get; set; }
        public string PixKeyValue { get; set; }
        public PixAddressRequest Address { get; set; }
        public string AdditionalData { get; set; }
        public PixTransactionPurpose? PixTransactionPurpose { get; set; }
        public PixKeyType PixKeyType { get; set; }
        public string Description { get; set; }
    }
}