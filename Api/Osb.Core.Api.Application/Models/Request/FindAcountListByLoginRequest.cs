namespace Osb.Core.Api.Application.Models.Request
{
    public class FindAcountListByLoginRequest : BaseRequest
    {
        public string Login { get; set; }
    }
}