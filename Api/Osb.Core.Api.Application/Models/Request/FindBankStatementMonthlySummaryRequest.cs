using System;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindBankStatementMonthlySummaryRequest : BaseRequest
    {
        public DateTime? DateMonthly { get; set; }
    }
}