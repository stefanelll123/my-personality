using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonality.Identity.Api.Controllers.Requests;
using MyPersonality.Identity.Api.Controllers.Responses;
using MyPersonality.Identity.Api.Extensions;
using MyPersonality.Identity.Application.Services;
using MyPersonality.Infrastructure.FunctionalExtensions;

namespace MyPersonality.Identity.Api.Controllers;

[ApiController]
[Route("identity/v1/identity")]
public sealed class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var response = await _identityService.Login(loginRequest.Email, loginRequest.Password);
        return response.IsSuccess ? Ok(response.Value.ToLoginResponse()) : response.Error.ToHttpResponse();
    }
}