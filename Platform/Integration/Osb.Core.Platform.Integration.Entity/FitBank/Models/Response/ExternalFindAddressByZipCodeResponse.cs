using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindAddressByZipCodeResponse : BaseResponse
    {
        public FindAddressByZipCodeResponse Address { get; set; }
    }
}