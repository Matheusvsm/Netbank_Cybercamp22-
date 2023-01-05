using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class NotificationServiceFactory : Interfaces.INotificationServiceFactory
    {
        private IServiceProvider _provider;

        public NotificationServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public INotificationService Create() => _provider.GetService<INotificationService>();
    }
}