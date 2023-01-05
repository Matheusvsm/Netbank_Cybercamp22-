using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class NewAccountPerson : BaseEntity
    {
        public long NewAccountPersonId { get; set;}
        public long NewAccountId { get; set;}
        public string TaxId { get; set;}
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Occupation { get; set; }
        public string Phone { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
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

        public static NewAccountPerson Create(long newAccountId, string taxId, string name, string mail, string ocupation, string phone, PersonRoleType personRoleType, string motherFullName,
            string fatherFullName, string nationality, string birthCity, string birthState, Gender gender, MaritalStatus maritalStatus, string spouseName, string identityDocument, CompanyType companyType,
            string companyActivity, DateTime constitutionDate, bool? checkPendingTransfers, DateTime birthDate, string personName, string phoneNumber, string nickName, bool publiclyExposedPerson, long userId)
        {
            return new NewAccountPerson{
                NewAccountId = newAccountId,
                TaxId = taxId,
                Name = name,
                Mail = mail,
                Occupation = ocupation,
                Phone = phone,
                PersonRoleType = personRoleType,
                MotherFullName = motherFullName,
                FatherFullName = fatherFullName,
                Nationality = nationality,
                BirthCity = birthCity,
                BirthState = birthState,
                Gender = gender,
                MaritalStatus = maritalStatus,
                SpouseName = spouseName,
                IdentityDocument = identityDocument,
                CompanyType = companyType,
                CompanyActivity = companyActivity,
                ConstitutionDate = constitutionDate,
                CheckPendingTransfers = checkPendingTransfers,
                BirthDate = birthDate,
                PersonName = personName,
                PhoneNumber = phoneNumber,
                Nickname = nickName,
                PubliclyExposedPerson = publiclyExposedPerson,
                CreationUserId = userId
            };
        }
    }
}