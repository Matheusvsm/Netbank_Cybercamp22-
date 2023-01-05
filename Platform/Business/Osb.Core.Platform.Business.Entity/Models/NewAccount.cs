using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class NewAccount : BaseEntity
    {
        public long NewAccountId { get; set; }
        public long CompanyId { get; set; }
        public string PersonName { get; set; }
        public string Nickname { get; set; }
        public string Mail { get; set; }
        public NewAccountStatus Status  {get; set; }
        public string PhoneNumber { get; set; }
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
		public string TaxId { get; set; }
		public bool PubliclyExposedPerson { get; set; }
		public string IdentityDocument{ get; set; }
		public CompanyType CompanyType { get; set; }
        public string CompanyActivity { get; set; }
		public DateTime ConstitutionDate { get; set; }
		public bool? CheckPendingTransfers { get; set; }
		public string Bank { get; set; }
		public string BankBranch { get; set; }
		public string BankAccount { get; set; }
		public string BankAccountDigit { get; set; }
        public int Attempts { get; set; }

        public static NewAccount Create(long companyId, string taxId, string personName, string phoneNumber, string mail, string nickname, DateTime birthDate, 
            string motherFullName, string fatherFullName, string nationality, string birthCity, string birthState, Gender gender, MaritalStatus maritalStatus, string spouseName, string occupation,
            CompanyType companyType, string companyActivity, DateTime constitutionDate, bool publiclyExposedPerson, bool? checkPendingTransfers, string identityDocument, string bank, string bankBranch,
            string bankAccount, string bankAccountDigit, long userId)
        {
            return new NewAccount
            {
                CompanyId = companyId,
                TaxId = taxId,
                PersonName = personName,
                PhoneNumber = phoneNumber,
                Mail = mail,
                Nickname = nickname,
                BirthDate = birthDate,
                MotherFullName = motherFullName,
                FatherFullName = fatherFullName,
                Nationality = nationality,
                BirthCity = birthCity,
                BirthState = birthState,
                Gender = gender,
                Status = NewAccountStatus.Created,
                MaritalStatus = maritalStatus,
                SpouseName = spouseName,
                Occupation = occupation,
                CompanyType = companyType,
                CompanyActivity = companyActivity,
                ConstitutionDate = constitutionDate,
                PubliclyExposedPerson = publiclyExposedPerson,
                CheckPendingTransfers = checkPendingTransfers,
                IdentityDocument = identityDocument,
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit,
                CreationUserId = userId
            };
        }
    }  
}