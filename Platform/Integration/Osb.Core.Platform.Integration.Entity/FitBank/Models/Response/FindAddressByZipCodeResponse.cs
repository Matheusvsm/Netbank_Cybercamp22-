namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindAddressByZipCodeResponse : BaseResponse
    {
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
    }
}