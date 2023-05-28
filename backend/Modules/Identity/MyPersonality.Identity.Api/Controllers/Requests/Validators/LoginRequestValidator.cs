using FluentValidation;

namespace MyPersonality.Identity.Api.Controllers.Requests.Validators;

internal sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(car => car.Email).NotEmpty();
        RuleFor(car => car.Password).NotEmpty();
    }
}