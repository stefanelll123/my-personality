using System.Net;
using MyPersonality.Infrastructure.FunctionalExtensions;
using Flurl.Http;

namespace MyPersonality.ApiGateway.Aggregator.Extensions;

internal static class FlurlResponseExtensions
{
    internal static Error ToError(this IFlurlResponse response)
    {
        return new Error((HttpStatusCode) response.StatusCode, response.GetStringAsync().Result);
    }
}