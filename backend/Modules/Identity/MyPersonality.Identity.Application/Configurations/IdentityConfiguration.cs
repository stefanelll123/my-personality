using System;

namespace MyPersonality.Identity.Application.Configurations;

internal sealed class IdentityConfiguration : IIdentityConfiguration
{
    public string? JwtSecret { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    
    string IIdentityConfiguration.JwtSecret => JwtSecret ?? throw new ArgumentNullException($"{nameof(JwtSecret)} is not defined");
    string IIdentityConfiguration.Issuer => Issuer ?? throw new ArgumentNullException($"{nameof(Issuer)} is not defined");
    string IIdentityConfiguration.Audience => Audience ?? throw new ArgumentNullException($"{nameof(Audience)} is not defined");
}