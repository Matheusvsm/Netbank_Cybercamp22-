using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class CardHolderRequest
    {
        public string HolderTaxId { get; set; }
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}