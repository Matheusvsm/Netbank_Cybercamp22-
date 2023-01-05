namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CardHolderRequest
    {
        public string HolderTaxNumber { get; set; }
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string MaritalStatus { get; set; }
    }
}