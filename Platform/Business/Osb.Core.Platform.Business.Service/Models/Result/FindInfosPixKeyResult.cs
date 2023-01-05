using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindInfosPixKeyResult
    {
        public long SearchProtocol { get; set; }
        public string PayeeName { get; set; }
        public string PayeeBankName { get; set; }
        public string PayeeBank { get; set; }
        public string PayeeBankBranch { get; set; }
        public string PayeeBankAccount { get; set; }
        public string PayeeBankAccountDigit { get; set; }
        public AccountType PayeeAccountType { get; set; }
        public PixKeyType PixKeyType { get; set; }
        public string PixKeyValue { get; set; }
        public string PayeeTaxNumber { get; set; }
    }
}