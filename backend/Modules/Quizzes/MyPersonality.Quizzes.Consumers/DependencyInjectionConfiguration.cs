using Microsoft.Extensions.DependencyInjection;

namespace MyPersonality.Quizzes.Consumers;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddQuizzesConsumers(this IServiceCollection service)
    {
        return service;
    }
}