using System;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class NewAccountRequest
    {
        public long CompanyId { get; set; }
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxId { get; set; }
        public string Nickname { get; set; }
        public string Mail { get; set; }
        public bool PubliclyExposedPerson { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public string Nationality { get; set; }
        public string BirthCity { get; set; }
        public string BirthState { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string Occupation { get; set; }
        public string IdentityDocument { get; set; }
        public CompanyType CompanyType { get; set; }
        public string CompanyActivity { get; set; }
        public DateTime ConstitutionDate { get; set; }
        public bool? CheckPendingTransfers { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public List<NewAccountAddressRequest> Addresses { get; set; }
        public List<NewAccountPersonDocumentRequest> Documents { get; set; }
        public List<NewAccountPersonRequest> Persons { get; set; }
    }
}