using FluentValidation;

namespace MyPersonality.Quizzes.Api.Controllers.Requests.Validators;

internal sealed class QuizSubmissionRequestValidator : AbstractValidator<QuizSubmissionRequest>
{
    public QuizSubmissionRequestValidator()
    {
        RuleFor(quiz => quiz.QuizId).NotNull();
    }
}

internal sealed class AnswerSubmissionRequestValidator : AbstractValidator<AnswerSubmissionRequest>
{
    public AnswerSubmissionRequestValidator()
    {
        RuleFor(question => question.QuestionId).NotNull();
        RuleFor(question => question.AnswerId).NotNull();
    }
}
