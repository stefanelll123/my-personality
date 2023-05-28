using MyPersonality.Quizzes.DataAccess.Adapters.Repositories;
using MyPersonality.Quizzes.Interop.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MyPersonality.Quizzes.DataAccess.Adapters;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterQuizzesDataAccess(this IServiceCollection service)
    {
        service.AddSingleton<DatabaseContext>();
        service.AddTransient<IQuizzesRepository, QuizzesRepository>();
        service.AddTransient<IQuizSubmissionsRepository, QuizSubmissionsRepository>();
        
        return service;
    }
}