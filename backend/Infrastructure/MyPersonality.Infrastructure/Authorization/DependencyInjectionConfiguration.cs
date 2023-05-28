using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace MyPersonality.Infrastructure.Authorization;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddTokenAuthorization(this IServiceCollection service)
    {
        service.AddSingleton<IAuthorizationHandler, AuthorizationHeaderHandler>();

        service.AddAuthorizationCore(options =>
        {
            options.AddPolicy(AuthorizationConstants.IsAuthorizedPolicy,
                policy => policy.Requirements.Add(new AuthorizationHeaderRequirement()));
        });
        
        return service;
    }
}