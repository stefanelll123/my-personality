using System.Linq;
using MyPersonality.Quizzes.Api.Controllers.Requests;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.Api.Extensions;

internal static class QuizSubmissionRequestExtensions
{
    internal static QuizSubmission ToQuizSubmission(this QuizSubmissionRequest quizSubmission) =>
        new(quizSubmission.QuizId,
            quizSubmission.AnswerSubmissions
                .Select(question => question.ToAnswerSubmission())
                .ToList());

    private static AnswerSubmission ToAnswerSubmission(this AnswerSubmissionRequest answer) =>
        new(answer.QuestionId, answer.AnswerId);
}