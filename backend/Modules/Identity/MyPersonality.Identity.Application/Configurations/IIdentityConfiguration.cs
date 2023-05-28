namespace MyPersonality.Identity.Application.Configurations;

internal interface IIdentityConfiguration
{
    string JwtSecret { get; }
    string Issuer { get; }
    string Audience { get; }
}