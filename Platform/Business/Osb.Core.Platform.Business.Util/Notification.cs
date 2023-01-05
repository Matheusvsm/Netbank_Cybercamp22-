using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Util
{
    public class Notification
    {

        public static void SendMail(long companyId, UserInformation userInformation, INotificationRepository notificationRepository, string title, string content)
        {

            MailNotification sendMail = MailNotification.Create(
                                                                userInformation.UserId,
                                                                companyId,
                                                                userInformation.Mail,
                                                                title,
                                                                content
                                                                );

            notificationRepository.Save(sendMail);
        }

        public static void SendSms(long companyId, UserInformation userInformation, INotificationRepository notificationRepository, string content)
        {

            SmsNotification sendSms = SmsNotification.Create(
                                                            userInformation.UserId,
                                                            companyId,
                                                            userInformation.PhoneNumber,
                                                            content
                                                            );

            notificationRepository.Save(sendSms);
        }

        public static void SendPush(long companyId, long operationId, UserInformation userInformation, INotificationRepository notificationRepository, string title, string content)
        {

            PushNotification pushNotification = PushNotification.Create(
                                                                        operationId,
                                                                        userInformation.UserId,
                                                                        companyId,
                                                                        title,
                                                                        content,
                                                                        PushNotificationStatus.CanBeSent
            );

            notificationRepository.Save(pushNotification);
        }
    }
}