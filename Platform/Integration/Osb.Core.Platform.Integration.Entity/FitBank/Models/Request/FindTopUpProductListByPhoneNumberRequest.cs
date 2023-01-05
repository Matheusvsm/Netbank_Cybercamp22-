using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindTopUpProductListByPhoneNumberRequest : BaseRequest
    {
        public new string Method { get => "GetTopUpProductsByPhone"; } 
        public string PhoneNumber { get; set; }  
        public TopUpProductSubType ProductSubType { get; set; }
       
    }
}     