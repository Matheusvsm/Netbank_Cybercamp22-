using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindAddressByZipCodeRequest : BaseRequest
    {
        public string Url { get; set; }
        public string ZipCode { get; set; }
    }
}