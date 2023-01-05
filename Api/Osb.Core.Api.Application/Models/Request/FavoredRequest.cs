using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FavoredRequest : BaseRequest
    {

        public string TaxId { get; set; }

        public string Name { get; set; }

        public OperationType Type { get; set; }

        public string BankName { get; set; }

        public string Bank { get; set; }

        public string BankBranch { get; set; }

        public string BankAccount { get; set; }

        public string BankAccountDigit { get; set; }

    }
}