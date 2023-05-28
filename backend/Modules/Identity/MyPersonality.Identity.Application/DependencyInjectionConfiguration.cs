using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Identity.Application.Configurations;
using MyPersonality.Identity.Application.Services;

namespace MyPersonality.Identity.Application;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterIdentityApplication(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddTransient<IIdentityService, IdentityService>();

        var identityConfiguration = configuration.GetSection("Identity")
            .Get<IdentityConfiguration>(c => c.BindNonPublicProperties = true);
        service.AddSingleton<IIdentityConfiguration>(identityConfiguration!);

        return service;
    }
}