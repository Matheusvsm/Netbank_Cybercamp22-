using System.Text.Json.Serialization;
namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class PixQRCode
    {
        public string PixKey { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PayerName { get; set; }
        public string PayerTaxNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverTaxNumber { get; set; }
        public string QRCodeBase64 { get; set; }
        public string HashCode { get; set; }
        public string CreationDate { get; set; }
        public string PrincipalValue { get; set; }
        public string ChangeType { get; set; }
        public string Status { get; set; }
        public string PixQRCodeType { get; set; }
        public string DueDate { get; set; }
        public decimal RebateValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal FineValue { get; set; }
        public bool Reusable { get; set; }
        public string PayerRequest { get; set; }
        public string ExpirationDate { get; set; }
        public string TransactionChangeType { get; set; }
        public string TransactionValue { get; set; }
        public string TransactionPurpose { get; set; }
        public string AgentModality { get; set; }
    }
}
