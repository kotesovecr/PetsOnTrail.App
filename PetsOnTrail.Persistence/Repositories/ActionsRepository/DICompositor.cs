using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

public static class DICompositor
{
    public static IServiceCollection AddActionsRepository(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig
            .AddGetActionResponse();

        services
            .AddScoped<IActionsRepository, ActionsRepository>();

        return services;
    }
}
