namespace MyPersonality.Identity.Api.Controllers.Responses;

public sealed class LoginResponse
{
    public LoginResponse(string token, string firstName, string lastName)
    {
        Token = token;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Token { get; }
    public string FirstName { get; }
    public string LastName { get; }
}