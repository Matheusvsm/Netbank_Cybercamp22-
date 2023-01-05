using Osb.Core.Platform.Common.Entity.Enums;
namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdatePixKeyStatusRequest
    {
        public long CompanyId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public PixKeyStatus PixKeyStatus { get; set; }
        public PixKeyType PixKeyType { get; set; }
        public string PixKey { get; set; }
    }
}