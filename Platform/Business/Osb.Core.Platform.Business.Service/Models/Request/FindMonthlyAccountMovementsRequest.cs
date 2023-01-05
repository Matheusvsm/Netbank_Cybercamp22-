using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindBankStatementMonthlySummaryRequest
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public DateTime? DateMonthly { get; set; }
    }
}