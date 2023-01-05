namespace Osb.Core.Api.Application.Models.Request
{
    public class GenerateHashCodeRequest : BaseRequest
    {
        public string Identifier { get; set; }
        public decimal Value { get; set; }
    }
}