using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindAccountOperationLimitRequest : BaseRequest
    {
        public new string Method { get => "GetAccountOperationLimit"; }
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public OperationType OperationType { get; set; }
        public AccountOperationLimitType AccountOperationLimitType { get; set; }
        public AccountOperationLimitSubType AccountOperationLimitSubType { get; set; }
    }
}