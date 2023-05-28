using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPersonality.Quizzes.Domain;
using CSharpFunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.Interop.Repositories;

public interface IQuizzesRepository
{
    public Task<IEnumerable<Quiz>> Get();
    public Task<Maybe<Quiz?>> Get(Guid id);
    public Task<Maybe<Guid>> Create(Quiz quiz);
    public Task Delete(Quiz quiz);
    public Task Update(Guid id, Quiz quiz);
}