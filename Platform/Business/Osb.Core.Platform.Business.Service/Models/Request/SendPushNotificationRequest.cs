namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class SendPushNotificationMessageRequest
    {
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}