namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountListByLoginRequest : BaseRequest
    {
        public string Login { get; set; }
        public long CompanyId { get; set; }
    }
}