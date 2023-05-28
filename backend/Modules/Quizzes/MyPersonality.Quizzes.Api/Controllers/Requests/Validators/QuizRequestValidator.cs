using FluentValidation;

namespace MyPersonality.Quizzes.Api.Controllers.Requests.Validators;

internal sealed class QuizRequestValidator : AbstractValidator<QuizRequest>
{
    public QuizRequestValidator()
    {
        RuleFor(quiz => quiz.Title).NotNull()
            .Length(5, 50);
        RuleFor(quiz => quiz.Description).NotNull()
            .Length(5, 200);
        RuleFor(quiz => quiz.Questions).NotEmpty();
        RuleFor(quiz => quiz.Placements).NotEmpty();
    }
}

internal sealed class QuestionRequestValidator : AbstractValidator<QuestionRequest>
{
    public QuestionRequestValidator()
    {
        RuleFor(question => question.Description).NotNull()
            .Length(5, 200);
        RuleFor(question => question.Answers).NotEmpty();
    }
}

internal sealed class AnswerRequestValidator : AbstractValidator<AnswerRequest>
{
    public AnswerRequestValidator()
    {
        RuleFor(question => question.Description).NotNull()
            .Length(5, 200);
        RuleFor(question => question.NumberOfPoints).NotEmpty();
    }
}

internal sealed class PlacementRequestValidator : AbstractValidator<PlacementRequest>
{
    public PlacementRequestValidator()
    {
        RuleFor(question => question.Description).NotNull()
            .Length(5, 200);
        RuleFor(question => question.MinScore).NotEmpty();
        RuleFor(question => question.MaxScore).NotEmpty();
    }
}
