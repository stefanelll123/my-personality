using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace MyPersonality.Quizzes.Api.Controllers.Requests.Validators;

public sealed class QuizUpdateRequestValidator : AbstractValidator<JsonPatchDocument<QuizUpdateRequest>>
{
    public QuizUpdateRequestValidator()
    {
        RuleFor(patchDocument => patchDocument.Operations.FirstOrDefault(x => x.path == "id"))
            .Null()
            .WithMessage("Cannot update the id of a quiz");
    }
}