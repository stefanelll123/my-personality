using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MyPersonality.Quizzes.Interop.Repositories;
using MyPersonality.Infrastructure.FunctionalExtensions;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.JsonPatch;
using MyPersonality.Quizzes.Domain.Aggregates;

[assembly: InternalsVisibleTo("MyPersonality.Quizzes.Tests")]

namespace MyPersonality.Quizzes.Application.Services;

internal sealed class QuizzesService : IQuizzesService
{
    private readonly IQuizzesRepository _quizzesRepository;
    private readonly IQuizSubmissionsRepository _quizSubmissionsRepository;

    public QuizzesService(IQuizzesRepository quizzesRepository, IQuizSubmissionsRepository quizSubmissionsRepository)
    {
        _quizzesRepository = quizzesRepository;
        _quizSubmissionsRepository = quizSubmissionsRepository;
    }
    
    public async Task<Result<IEnumerable<Quiz>>> GetQuizzes()
    {
        return await Result.Try(() => _quizzesRepository.Get());
    }

    public async Task<Result<Quiz, Error>> GetQuiz(Guid id)
    {
        return await Result.Try(() => _quizzesRepository.Get(id), error => new Error(error))
            .Ensure(quiz => quiz.HasValue, _ => new Error(HttpStatusCode.NotFound, $"Cannot find any quiz with id {id}"))
            .OnSuccessTry(quiz => quiz.Value!);
    }
    
    public async Task<Result<Guid, Error>> AddQuiz(Quiz quiz)
    {
        return await Result.Try(() => _quizzesRepository.Create(quiz), error => new Error(error))
            .Ensure(newQuizId => newQuizId.HasValue,
                _ => new Error(HttpStatusCode.InternalServerError, "Unable to create the new quiz."))
            .OnSuccessTry(newQuizId => newQuizId.Value);
    }

    public async Task<UnitResult<Error>> RemoveQuiz(Guid id)
    {
        return await Result.Try(() => _quizzesRepository.Get(id), error => new Error(error))
            .Ensure(quiz => quiz.HasValue, _ => new Error(HttpStatusCode.NotFound, $"Cannot find any quiz with id {id}"))
            .OnSuccessTry(quiz => _quizzesRepository.Delete(quiz.Value!));
    }

    public async Task<Result<Quiz, Error>> UpdateQuiz(Guid id, JsonPatchDocument<Quiz> patchDocument)
    {
        return await Result.Try(() => _quizzesRepository.Get(id), error => new Error(error))
            .Ensure(quiz => quiz.HasValue, _ => new Error(HttpStatusCode.NotFound, $"Cannot find any quiz with id {id}"))
            .OnSuccessTry(quiz => quiz.Value!)
            .Tap(quiz => patchDocument.ApplyTo(quiz, _ => {}))
            .Tap(quiz => _quizzesRepository.Update(id, quiz));
    }

    public async Task<Result<string, Error>> GetPlacement(Guid id, Guid submissionId)
    {
        Quiz? quiz = null;
        QuizSubmission? quizSubmission = null;

        return await Result.Try(() => _quizzesRepository.Get(id), e => new Error(e))
            .Ensure(q => q.HasValue, _ => new Error(HttpStatusCode.NotFound, $"Cannot find any quiz with id {id}"))
            .OnSuccessTry(q => quiz = q.Value!)
            .OnSuccessTry(_ => _quizSubmissionsRepository.Get(submissionId))
            .Ensure(qs => qs.HasValue,
                _ => new Error(HttpStatusCode.NotFound, $"Cannot find any quiz submission with id {id}"))
            .OnSuccessTry(qs => quizSubmission = qs.Value!)
            .Ensure(_ => quizSubmission!.QuizId == quiz!.Id,
                _ => new Error(HttpStatusCode.BadRequest,
                    $"The submission with id {submissionId} is not a submission for the quiz with id {id}"))
            .OnSuccessTry(_ => CalculatePlacement(quiz!, quizSubmission!), _ => new Error(HttpStatusCode.InternalServerError, "Unable to calculate the placement"));
    }

    private static string CalculatePlacement(Quiz quiz, QuizSubmission quizSubmission)
    {
        var score = 0;
        foreach (var answerSubmission in quizSubmission.AnswerSubmissions)
        {
            var question = quiz.Questions.First(q => q.Id == answerSubmission.QuestionId);
            var answer = question.Answers.First(a => a.Id == answerSubmission.AnswerId);

            score += answer.NumberOfPoints;
        }

        return quiz.Placements.First(p => p.MinScore <= score && score <= p.MaxScore).Description;
    }
}
