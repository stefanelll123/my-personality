using System.Reflection;
using MyPersonality.Quizzes.Api;
using MyPersonality.Quizzes.Application;
using MyPersonality.Quizzes.Consumers;
using MyPersonality.Quizzes.DataAccess.Adapters;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Infrastructure.Authorization;

namespace MyPersonality.Quizzes.Bootstrap;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterQuizzesModule(this IServiceCollection service)
    {
        return service.RegisterQuizzesApplication()
            .RegisterQuizzesDataAccess()
            .AddQuizzesConsumers()
            .AddMappings()
            .AddValidators()
            .AddTokenAuthorization();
    }
    
    public static IMvcBuilder RegisterQuizzesModuleControllers(this IMvcBuilder mvcBuilder)
    {
        return mvcBuilder
            .AddApplicationPart(Assembly.GetAssembly(typeof(QuizzesAssembly))!);
    }
}