using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Persistence.Repositories.ActionsRepository;

namespace PetsOnTrail.Persistence;

public static class DICompositor
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .AddBlazoredLocalStorage()
            .AddActionsRepository();

        return services;
    }
}
