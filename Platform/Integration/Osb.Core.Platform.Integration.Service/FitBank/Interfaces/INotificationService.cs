using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface INotificationService
    {
        void SendMail(SendMailRequest sendMailRequest);
        void SendSms(SendSmsRequest sendSmsRequest);
        void SendPushNotification(SendPushNotificationRequest sendPushNotificationRequest);
    }
}