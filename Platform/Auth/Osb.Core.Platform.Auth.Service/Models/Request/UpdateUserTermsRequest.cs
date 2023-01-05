namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class UpdateUserTermsRequest : BaseRequest
    {
        public string Login { get; set; }
        public long CompanyId { get; set; }
    }
}