namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAddressByZipCodeResult
    {
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
    }
}