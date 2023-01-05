namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountByPhoneNumberRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
        public long CompanyId { get; set; }
    }
}