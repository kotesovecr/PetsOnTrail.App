using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

public static class DICompositor
{
    public static IServiceCollection AddActionsRepository(this IServiceCollection services)
    {
        services
            .AddScoped<IActionsRepository, ActionsRepository>();

        return services;
    }
}
