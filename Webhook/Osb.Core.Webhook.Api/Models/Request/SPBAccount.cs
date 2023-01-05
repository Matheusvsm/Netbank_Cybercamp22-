using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class SPBAccount
    {
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}