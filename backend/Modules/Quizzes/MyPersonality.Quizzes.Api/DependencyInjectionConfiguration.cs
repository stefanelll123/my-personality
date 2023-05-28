using MyPersonality.Quizzes.Api.Controllers.Requests;
using MyPersonality.Quizzes.Api.Controllers.Requests.Validators;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Quizzes.Api.Controllers.Responses;

namespace MyPersonality.Quizzes.Api;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddMappings(this IServiceCollection service)
    {
        service.AddAutoMapper(config =>
        {
            config.CreateMap<JsonPatchDocument<QuizUpdateRequest>, JsonPatchDocument<QuizResponse>>();
            config.CreateMap<Operation<QuizUpdateRequest>, Operation<QuizResponse>>();
        });
        
        return service;
    }
    
    public static IServiceCollection AddValidators(this IServiceCollection service)
    {
        service.AddTransient<IValidator<QuizRequest>, QuizRequestValidator>();
        service.AddTransient<IValidator<QuestionRequest>, QuestionRequestValidator>();
        service.AddTransient<IValidator<AnswerRequest>, AnswerRequestValidator>();
        service.AddTransient<IValidator<PlacementRequest>, PlacementRequestValidator>();
        service.AddTransient<IValidator<JsonPatchDocument<QuizUpdateRequest>>, QuizUpdateRequestValidator>();
        
        service.AddTransient<IValidator<QuizSubmissionRequest>, QuizSubmissionRequestValidator>();
        service.AddTransient<IValidator<AnswerSubmissionRequest>, AnswerSubmissionRequestValidator>();
        
        return service;
    }
}