using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Identity.Application.Dtos;
using MyPersonality.Infrastructure.FunctionalExtensions;

namespace MyPersonality.Identity.Application.Services;

public interface IIdentityService
{
    Task<Result<TokenDto, Error>> Login(string email, string password);

    bool ValidateBearerToken(string token);
}