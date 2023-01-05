using Osb.Core.Platform.Common.Entity.Enums;
namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindTopUpProductListByPhoneNumberRequest : BaseRequest
    {
        public  TopUpProductSubType ProductSubType { get; set; }
        public string PhoneNumber { get; set; }        
    }
}