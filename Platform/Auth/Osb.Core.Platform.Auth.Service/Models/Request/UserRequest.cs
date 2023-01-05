namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class UserRequest
    {
        public string TaxId { get; set; }
        public string AccountName { get; set; }
        public string AccountTaxId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public long Status { get; set; }
        public long Type { get; set; }
        public string UserTaxId { get; set; }
        public long EventType { get; set; }
        public long CompanyId { get; set; }
    }
}