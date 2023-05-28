namespace MyPersonality.Identity.Api.Controllers.Requests;

public sealed class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}