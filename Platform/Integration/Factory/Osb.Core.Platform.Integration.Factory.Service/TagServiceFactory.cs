using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class TagServiceFactory: ITagServiceFactory
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