using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class CardHolderContact : BaseEntity
    {
        public long CardHolderContactId { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public static CardHolderContact Create(long userId, string phone, string mail)
        {
            return new CardHolderContact
            {
                Phone = phone,
                Mail = mail,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}