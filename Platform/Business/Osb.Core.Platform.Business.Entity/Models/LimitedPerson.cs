using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class LimitedPerson : BaseEntity
    {
        public long LimitedAccountId { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
        public DateTime BirthDate { get; set; }

        public static LimitedPerson Create(long limitedAccountId, string name, string taxNumber, string mail, string phone, PersonRoleType personRoleType, DateTime birthDate, long userId)
        {
            return new LimitedPerson
            {
                LimitedAccountId = limitedAccountId,
                Name = name,
                TaxNumber = taxNumber,
                Mail = mail,
                Phone = phone,
                PersonRoleType = personRoleType,
                BirthDate = birthDate,
                CreationUserId = userId
            };
        }
    }
}