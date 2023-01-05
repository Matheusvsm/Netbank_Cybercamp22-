using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class Card
    {
        public string FullName { get; set; }
        public string IdentifierCard { get; set; }
        public string PanLastDigits { get; set; }
        public bool IsBlocked { get; set; }
        public CardStatus Status { get; set; }
    }
}