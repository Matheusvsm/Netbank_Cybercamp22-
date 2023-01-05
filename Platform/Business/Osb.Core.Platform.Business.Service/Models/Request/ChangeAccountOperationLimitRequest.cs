namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class ChangeAccountOperationLimitRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public long CompanyId { get; set; }
        public int OperationType { get; set; }
        public int AccountOperationLimitType { get; set; }
        public int AccountOperationLimitSubType { get; set; }
        public decimal MinLimitValue { get; set; }
        public int MaxLimitValue { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }


    }
}