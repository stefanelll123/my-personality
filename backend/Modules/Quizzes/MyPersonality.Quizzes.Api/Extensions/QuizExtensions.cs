using System.Collections.Generic;
using System.Linq;
using MyPersonality.Quizzes.Api.Controllers.Requests;
using MyPersonality.Quizzes.Api.Controllers.Responses;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.Api.Extensions;

internal static class QuizExtensions
{
    internal static IEnumerable<QuizResponse> ToQuizResponses(this IEnumerable<Quiz> quizzes) =>
        quizzes.Select(quiz => quiz.ToQuizResponse());

    internal static QuizResponse ToQuizResponse(this Quiz quiz) =>
        new(quiz.Id, quiz.Title, quiz.Description,
            quiz.Questions.Select(question => question.ToQuestionResponse()).ToList(),
            quiz.Placements.Select(placement => placement.ToPlacementResponse()).ToList());

    private static QuestionResponse ToQuestionResponse(this Question question) =>
        new(question.Id, question.Description, question.Answers.Select(answer => answer.ToAnswerResponse()).ToList());

    private static PlacementResponse ToPlacementResponse(this Placement placement) =>
        new(placement.Id, placement.Description, placement.MinScore, placement.MaxScore);

    private static AnswerResponse ToAnswerResponse(this Answer answer) =>
        new(answer.Id, answer.Description, answer.NumberOfPoints);
}