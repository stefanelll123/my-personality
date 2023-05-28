using MediatR;

namespace MyPersonality.IntegrationEvents.Command;

public sealed class ValidateTokenCommand : IRequest<ValidateTokenCommandResponse>
{
    public ValidateTokenCommand(string token)
    {
        Token = token;
    }

    public string Token { get; }
}

public sealed class ValidateTokenCommandResponse
{
    public ValidateTokenCommandResponse(bool isTokenValid)
    {
        IsTokenValid = isTokenValid;
    }

    public bool IsTokenValid { get; }
}