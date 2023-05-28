using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Identity.Consumers.Consumers;

namespace MyPersonality.Identity.Consumers;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddIdentityConsumers(this IServiceCollection service)
    {
        service.AddMediatR(typeof(TokenValidationCommandConsumer).Assembly);
        return service;
    }
}