using System;

namespace MyPersonality.ApiGateway.Aggregator.Configurations;

internal sealed class ServicesEndpointsConfiguration : IServicesEndpointsConfiguration
{
    public string? IdentityService { get; set; }
    public string? QuizzesService { get; set; }

    string IServicesEndpointsConfiguration.IdentityService => IdentityService ?? throw new ArgumentNullException($"{nameof(IdentityService)} is not defined");

    string IServicesEndpointsConfiguration.QuizzesService => QuizzesService ?? throw new ArgumentNullException($"{nameof(QuizzesService)} is not defined");
}