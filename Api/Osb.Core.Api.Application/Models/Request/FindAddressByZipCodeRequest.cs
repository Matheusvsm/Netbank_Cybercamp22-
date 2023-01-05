namespace Osb.Core.Api.Application.Models.Request
{
    public class FindAddressByZipCodeRequest : BaseRequest
    {
        public string ZipCode { get; set; }
    }
}