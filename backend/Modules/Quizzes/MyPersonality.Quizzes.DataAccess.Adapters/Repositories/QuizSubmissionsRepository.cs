using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Interop.Repositories;

namespace MyPersonality.Quizzes.DataAccess.Adapters.Repositories;

internal sealed class QuizSubmissionsRepository : IQuizSubmissionsRepository
{
    private readonly DatabaseContext _databaseContext;
    
    public QuizSubmissionsRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<Maybe<QuizSubmission?>> Get(Guid id)
    {
        var quizSubmission = _databaseContext.QuizSubmissions.FirstOrDefault(qs => qs.Id == id);
        return Task.FromResult(Maybe.From(quizSubmission));
    }

    public Task<Maybe<Guid>> Create(QuizSubmission quizSubmission)
    {
        _databaseContext.QuizSubmissions.Add(quizSubmission);
        
        return Task.FromResult(Maybe.From(quizSubmission.Id));
    }
}