namespace Osb.Core.Api.Application.Models.Request
{
    public class SendPushNotificationRequest
    {
        public string Token { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; } 
    }
}