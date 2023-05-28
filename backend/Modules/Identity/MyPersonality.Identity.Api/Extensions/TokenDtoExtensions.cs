using MyPersonality.Identity.Api.Controllers.Responses;
using MyPersonality.Identity.Application.Dtos;

namespace MyPersonality.Identity.Api.Extensions;

internal static class TokenDtoExtensions
{
    public static LoginResponse ToLoginResponse(this TokenDto tokenDto) =>
        new(token: tokenDto.Token, firstName: tokenDto.FirstName, lastName: tokenDto.LastName);
}