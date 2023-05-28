using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Identity.Api.Controllers.Requests;
using MyPersonality.Identity.Api.Controllers.Requests.Validators;

namespace MyPersonality.Identity.Api;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddValidators(this IServiceCollection service)
    {
        service.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
        
        return service;
    }
}