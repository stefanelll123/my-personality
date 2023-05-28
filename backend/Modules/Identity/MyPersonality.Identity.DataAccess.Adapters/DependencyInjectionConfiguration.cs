using Microsoft.Extensions.DependencyInjection;
using MyPersonality.Identity.DataAccess.Adapters.Repositories;
using MyPersonality.Identity.Interop.Repositories;

namespace MyPersonality.Identity.DataAccess.Adapters;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterIdentityDataAccess(this IServiceCollection service)
    {
        service.AddSingleton<DatabaseContext>();
        service.AddTransient<IUsersRepository, UsersRepository>();
        
        return service;
    }
}