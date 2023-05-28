using System.Reflection;
using Microsoft.Extensions.Configuration;
using MyPersonality.Identity.Api;
using MyPersonality.Identity.Application;
using MyPersonality.Identity.DataAccess.Adapters;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Identity.Consumers;

namespace MyPersonality.Identity.Bootstrap;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterIdentityModule(this IServiceCollection service, IConfiguration configuration)
    {
        return service.RegisterIdentityApplication(configuration)
            .RegisterIdentityDataAccess()
            .AddIdentityConsumers()
            .AddValidators();
    }
    
    public static IMvcBuilder RegisterIdentityModuleControllers(this IMvcBuilder mvcBuilder)
    {
        return mvcBuilder
            .AddApplicationPart(Assembly.GetAssembly(typeof(IdentityAssembly))!);
    }
}