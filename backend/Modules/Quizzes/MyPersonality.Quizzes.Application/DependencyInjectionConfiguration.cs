using MyPersonality.Quizzes.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MyPersonality.Quizzes.Application;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterQuizzesApplication(this IServiceCollection service)
    {
        service.AddTransient<IQuizzesService, QuizzesService>();
        service.AddTransient<IQuizSubmissionsService, QuizSubmissionsService>();
        
        return service;
    }
}