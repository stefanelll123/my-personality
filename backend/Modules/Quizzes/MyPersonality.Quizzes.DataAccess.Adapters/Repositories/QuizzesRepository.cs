using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPersonality.Quizzes.Interop.Repositories;
using CSharpFunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.DataAccess.Adapters.Repositories;

internal sealed class QuizzesRepository : IQuizzesRepository
{
    private readonly DatabaseContext _databaseContext;
    
    public QuizzesRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task<IEnumerable<Quiz>> Get()
    {
        return await Task.FromResult(_databaseContext.Quizzes);
    }

    public Task<Maybe<Quiz?>> Get(Guid id)
    {
        var quiz = _databaseContext.Quizzes.FirstOrDefault(q => q.Id == id);
        return Task.FromResult(Maybe.From(quiz));
    }

    public Task<Maybe<Guid>> Create(Quiz quiz)
    {
        _databaseContext.Quizzes.Add(quiz);

        return Task.FromResult(Maybe.From(quiz.Id));
    }

    public Task Delete(Quiz quiz)
    {
        _databaseContext.Quizzes.Remove(quiz);
        return Task.CompletedTask;
    }

    public Task Update(Guid id, Quiz quiz)
    {
        var oldQuiz = _databaseContext.Quizzes.FirstOrDefault(x => x.Id == id);
        if (oldQuiz != null)
        {
            _databaseContext.Quizzes.Remove(oldQuiz);
            _databaseContext.Quizzes.Add(quiz);
        }
        
        return Task.CompletedTask;;
    }
}