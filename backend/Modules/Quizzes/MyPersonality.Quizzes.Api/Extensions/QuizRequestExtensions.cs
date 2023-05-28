using System.Linq;
using MyPersonality.Quizzes.Api.Controllers.Requests;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.Api.Extensions;

internal static class QuizRequestExtensions
{
    internal static Quiz ToQuiz(this QuizRequest quiz) =>
        new(quiz.Title, quiz.Description,
            quiz.Questions.Select(question => question.ToQuestion()).ToList(),
            quiz.Placements.Select(placement => placement.ToPlacement()).ToList());

    private static Question ToQuestion(this QuestionRequest question) =>
        new(question.Description, question.Answers.Select(answer => answer.ToAnswer()).ToList());

    private static Placement ToPlacement(this PlacementRequest placement) =>
        new(placement.Description, placement.MinScore, placement.MaxScore);

    private static Answer ToAnswer(this AnswerRequest answer) =>
        new(answer.Description, answer.NumberOfPoints);
}