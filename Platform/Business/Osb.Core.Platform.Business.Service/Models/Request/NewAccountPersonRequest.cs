using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class NewAccountPersonRequest
    {
        public string TaxId { get; set;}
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Occupation { get; set; }
        public string Phone { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
        public List<NewAccountPersonDocumentRequest> PersonDocuments { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public string Nationality { get; set; }
        public string BirthCity { get; set; }
        public string BirthState { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string IdentityDocument { get; set; }
        public CompanyType CompanyType { get; set; }
        public string CompanyActivity { get; set; }
        public DateTime ConstitutionDate { get; set; }
        public bool? CheckPendingTransfers { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string Nickname { get; set; }
        public bool PubliclyExposedPerson { get; set; }
    }
}