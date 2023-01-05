using Osb.Core.Platform.Common.Entity.Enums;
namespace Osb.Core.Api.Application.Models.Request
{
    public class FindTopUpProductListByPhoneNumberRequest : BaseRequest
    {
        public TopUpProductSubType ProductSubType { get; set; }
        public string PhoneNumber { get; set; }
    }
}