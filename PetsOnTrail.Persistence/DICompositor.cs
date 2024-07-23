using Blazored.LocalStorage;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Persistence.Repositories.ActionsRepository;

namespace PetsOnTrail.Persistence;

public static class DICompositor
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig)
    {
        services
            .AddBlazoredLocalStorage()
            .AddActionsRepository(typeAdapterConfig);

        return services;
    }
}
