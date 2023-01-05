using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class TagServiceFactory : ITagServiceFactory
    {
        private readonly IServiceProvider _provider;

        public TagServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITagService Create()
        {
            return _provider.GetService<ITagService>();
        }
    }
}