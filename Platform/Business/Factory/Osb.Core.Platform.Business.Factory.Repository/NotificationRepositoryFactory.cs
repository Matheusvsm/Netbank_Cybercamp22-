using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class NotificationRepositoryFactory : Interfaces.INotificationRepositoryFactory
    {
        private IServiceProvider _provider;

        public NotificationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public INotificationRepository Create() => _provider.GetService<INotificationRepository>();
    }
}