using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyPersonality.Identity.Application.Services;
using MyPersonality.IntegrationEvents.Command;

namespace MyPersonality.Identity.Consumers.Consumers;

public sealed class TokenValidationCommandConsumer : IRequestHandler<ValidateTokenCommand, ValidateTokenCommandResponse>
{
    private readonly IIdentityService _identityService;

    public TokenValidationCommandConsumer(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public Task<ValidateTokenCommandResponse> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ValidateTokenCommandResponse(_identityService.ValidateBearerToken(request.Token)));
    }
}