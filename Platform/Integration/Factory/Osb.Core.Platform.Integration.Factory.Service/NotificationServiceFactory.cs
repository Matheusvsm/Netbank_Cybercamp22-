using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class NotificationServiceFactory : Interfaces.INotificationServiceFactory
    {
        private IServiceProvider _provider;

        public NotificationServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public INotificationService Create()
        {
            return _provider.GetService<INotificationService>();
        }
    }
}