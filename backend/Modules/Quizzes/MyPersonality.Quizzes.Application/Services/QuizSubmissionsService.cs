using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Infrastructure.FunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Interop.Repositories;

[assembly: InternalsVisibleTo("MyPersonality.Quizzes.Tests")]

namespace MyPersonality.Quizzes.Application.Services;

internal sealed class QuizSubmissionsService : IQuizSubmissionsService
{
    private readonly IQuizSubmissionsRepository _quizSubmissionsRepository;

    public QuizSubmissionsService(IQuizSubmissionsRepository quizSubmissionsRepository)
    {
        _quizSubmissionsRepository = quizSubmissionsRepository;
    }

    public async Task<Result<Guid, Error>> AddQuizSubmission(QuizSubmission quizSubmission)
    {
        return await Result.Try(() => _quizSubmissionsRepository.Create(quizSubmission), error => new Error(error))
            .Ensure(newQuizSubmissionId => newQuizSubmissionId.HasValue,
                _ => new Error(HttpStatusCode.InternalServerError, "Unable to create a new quiz submission."))
            .OnSuccessTry(newQuizSubmissionId => newQuizSubmissionId.Value);
    }
}
