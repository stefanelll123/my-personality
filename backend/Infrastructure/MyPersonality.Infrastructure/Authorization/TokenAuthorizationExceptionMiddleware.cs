using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyPersonality.Infrastructure.Authorization;

public sealed class TokenAuthorizationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public TokenAuthorizationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (TokenAuthorizationFailureException)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Unauthorized");
        }
    }
}