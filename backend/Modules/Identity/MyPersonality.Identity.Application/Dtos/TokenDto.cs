namespace MyPersonality.Identity.Application.Dtos;

public sealed class TokenDto
{
    public TokenDto(string token, string firstName, string lastName)
    {
        Token = token;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Token { get; }
    public string FirstName { get; }
    public string LastName { get; }
}