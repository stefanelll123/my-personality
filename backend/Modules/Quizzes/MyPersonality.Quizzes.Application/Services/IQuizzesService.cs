using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPersonality.Infrastructure.FunctionalExtensions;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.JsonPatch;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.Application.Services;

public interface IQuizzesService
{
    Task<Result<IEnumerable<Quiz>>> GetQuizzes();
    Task<Result<Quiz, Error>> GetQuiz(Guid id);
    Task<Result<Guid, Error>> AddQuiz(Quiz quiz);
    Task<UnitResult<Error>> RemoveQuiz(Guid id);
    Task<Result<Quiz, Error>> UpdateQuiz(Guid id, JsonPatchDocument<Quiz> patchDocument);
    Task<Result<string, Error>> GetPlacement(Guid id, Guid submissionId);
}