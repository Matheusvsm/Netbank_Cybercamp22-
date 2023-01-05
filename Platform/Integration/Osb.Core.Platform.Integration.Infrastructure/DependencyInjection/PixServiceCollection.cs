using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
  public class PixServiceCollection
  {
    public static void AddScopedFactories(IServiceCollection services)
    {
      services.AddScoped<IPixService, PixService>();
      services.AddScoped<IPixServiceFactory, PixServiceFactory>();
    }

    public static void AddSingletonFactories(IServiceCollection services)
    {
      services.AddSingleton<IPixService, PixService>();
      services.AddSingleton<IPixServiceFactory, PixServiceFactory>();
    }
  }
}