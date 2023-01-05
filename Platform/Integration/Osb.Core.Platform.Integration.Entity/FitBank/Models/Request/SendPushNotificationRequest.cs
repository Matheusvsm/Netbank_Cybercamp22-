namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class SendPushNotificationRequest
    {
        public string Token { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}