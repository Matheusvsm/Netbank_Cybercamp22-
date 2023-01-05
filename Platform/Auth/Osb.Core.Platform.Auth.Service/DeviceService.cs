using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Service
{
    public class NotificationService : IDeviceService
    {
        private readonly IDeviceRepositoryFactory _notificationRepositoryFactory;
        private readonly Settings _settings;

        public NotificationService(
            IDeviceRepositoryFactory notificationRepositoryFactory,
            Settings settings
        )
        {
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _settings = settings;
        }

        public void RegisterDevice(RegisterUserDeviceRequest registerDeviceRequest)
        {

            Device device = Device.Create(
                            registerDeviceRequest.Token,
                            registerDeviceRequest.UserId,
                            registerDeviceRequest.CompanyId);

            IDeviceRepository notificationRepository = _notificationRepositoryFactory.Create();
            Device registeredDevice = notificationRepository.GetDeviceByUserIdAndCompanyId(registerDeviceRequest.UserId, registerDeviceRequest.CompanyId);

            if (registeredDevice == null)
            {
                notificationRepository.SaveDevice(device);
                return;
            }

            if (registeredDevice.Token == registerDeviceRequest.Token)
            {
                notificationRepository.DeleteDevice(registeredDevice.Token);
                notificationRepository.SaveDevice(device);
                return;
            }

            notificationRepository.UpdateDeviceToken(registerDeviceRequest.Token, registeredDevice.UserId);
        }
    }
}