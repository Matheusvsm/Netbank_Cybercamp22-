using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;
namespace Osb.Core.Platform.Business.Entity.Models
{
    public class CardHolder : BaseEntity
    {
        public long CardHolderId { get; set; }
        public string HolderTaxId { get; set; }
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public static CardHolder Create(long userId, string holderTaxId, string nationality, string motherName, Gender gender, string fullName, string birthDate, MaritalStatus maritalStatus)
        {
            return new CardHolder
            {
                HolderTaxId = holderTaxId,
                Nationality = nationality,
                MotherName = motherName,
                Gender = gender,
                FullName = fullName,
                BirthDate = birthDate,
                MaritalStatus = maritalStatus,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}