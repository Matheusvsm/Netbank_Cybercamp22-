namespace Osb.Core.Api.Application.Models.Request
{
    public class FindAccountByPhoneNumberRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
    }
}