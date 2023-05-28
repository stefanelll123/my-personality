using System;
using System.Threading.Tasks;
using MyPersonality.Infrastructure.FunctionalExtensions;
using CSharpFunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.Application.Services;

public interface IQuizSubmissionsService
{
    Task<Result<Guid, Error>> AddQuizSubmission(QuizSubmission quiz);
}