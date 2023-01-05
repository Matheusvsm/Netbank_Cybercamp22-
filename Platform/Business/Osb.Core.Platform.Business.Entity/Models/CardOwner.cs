using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class CardOwner : BaseEntity
    {
		public long CardOwnerId { get; set; }
        public string OwnerTaxId { get; set; }
		public string FullName { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public string Bank { get; set; }
		public string BankBranch { get; set; }
		public string BankAccount { get; set; }
		public string BankAccountDigit { get; set; }

		public static CardOwner Create(long userId, string ownerTaxId, string fullName, string phone, string mail, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
		{
			return new CardOwner
			{
				OwnerTaxId = ownerTaxId,
				FullName = fullName,
				Phone = phone,
				Mail = mail,
				Bank = bank,
				BankBranch = bankBranch,
				BankAccount = bankAccount,
				BankAccountDigit = bankAccountDigit,
				CreationUserId = userId,
				UpdateUserId = userId
			};
		}
    }
}