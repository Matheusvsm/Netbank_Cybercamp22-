using System;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class LimitedAccountRequest
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxId { get; set; }
        public string Mail { get; set; }
        public string Nickname { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public List<LimitedPersonRequest> Persons { get; set; }
        public string TradingName { get; set; }
        public string LegalName { get; set; }
        public DateTime? ConstitutionDate { get; set; }
    }
}
