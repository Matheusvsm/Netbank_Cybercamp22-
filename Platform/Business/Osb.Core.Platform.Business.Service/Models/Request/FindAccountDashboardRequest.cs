namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountDashboardRequest : BaseRequest
    {
        public string Login { get; set; }
        public long CompanyId { get; set; }
    }
}