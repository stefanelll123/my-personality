using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using MyPersonality.IntegrationEvents.Command;

namespace MyPersonality.Infrastructure.Authorization;

internal sealed class AuthorizationHeaderHandler : AuthorizationHandler<AuthorizationHeaderRequirement>
{
    private readonly IMediator _mediator;

    public AuthorizationHeaderHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationHeaderRequirement requirement)
    {
        var httpContext = context.Resource as HttpContext;
        if (httpContext?.Request?.Headers?.TryGetValue("Authorization", out var token) == true)
        {
            var response = await _mediator.Send(new ValidateTokenCommand(token.ToString()));
            if (!response.IsTokenValid)
            {
                throw new TokenAuthorizationFailureException();
            }
            
            context.Succeed(requirement);
        }
        else
        {
            throw new TokenAuthorizationFailureException();
        }
    }
}