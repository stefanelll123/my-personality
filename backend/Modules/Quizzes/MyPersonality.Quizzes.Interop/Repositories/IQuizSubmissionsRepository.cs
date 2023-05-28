using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.Interop.Repositories;

public interface IQuizSubmissionsRepository
{
    public Task<Maybe<QuizSubmission?>> Get(Guid id);
    public Task<Maybe<Guid>> Create(QuizSubmission quizSubmission);
}