using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using MyPersonality.Identity.Application.Configurations;
using MyPersonality.Identity.Application.Dtos;
using MyPersonality.Identity.Interop.Repositories;
using MyPersonality.Infrastructure.FunctionalExtensions;

namespace MyPersonality.Identity.Application.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly IUsersRepository _repository;
    private readonly IIdentityConfiguration _identityConfiguration;

    public IdentityService(IUsersRepository repository, IIdentityConfiguration identityConfiguration)
    {
        _repository = repository;
        _identityConfiguration = identityConfiguration;
    }
    
    public async Task<Result<TokenDto, Error>> Login(string email, string password)
    {
        return await Result.Try(() => CreatePasswordHash(password), e => new Error(e))
            .OnSuccessTry(passwordHash => _repository.GetUser(email, passwordHash))
            .Ensure(user => user.HasValue, _ => new Error(HttpStatusCode.Unauthorized, "Invalid credentials."))
            .OnSuccessTry(user => user.Value!)
            .OnSuccessTry(user => (user, token: CreateJwtToken(user.Email.ToString(), _identityConfiguration.JwtSecret,
                                                    _identityConfiguration.Issuer, _identityConfiguration.Audience)))
            .OnSuccessTry(input => new TokenDto(input.token, input.user.FirstName, input.user.LastName));
    }

    public bool ValidateBearerToken(string bearerToken)
    {
        if (!bearerToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }
        var token = bearerToken["Bearer ".Length..].Trim();
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityConfiguration.JwtSecret));
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _identityConfiguration.Issuer,
                ValidAudience = _identityConfiguration.Audience,
                IssuerSigningKey = securityKey,
            }, out _);
        }
        catch
        {
            return false;
        }
        return true;
    }

    private static string CreatePasswordHash(string password)
    {
        using var sha256Hash = SHA256.Create();
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();  
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        } 
        
        return builder.ToString();
    }

    private static string CreateJwtToken(string email, string jwtSecret, string issuer, string audience)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new []{new Claim(ClaimTypes.Email, email)},
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signingCredentials
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);
        
        return tokenString;
    }
}