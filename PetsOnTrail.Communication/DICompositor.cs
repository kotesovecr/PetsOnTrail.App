using Mapster;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Communication.gRPC;

namespace PetsOnTrail.Communication;

public static class DICompositor
{
    public static IServiceCollection AddCommunication(this IServiceCollection services, WebAssemblyHostConfiguration configuration, TypeAdapterConfig typeAdapterConfig)
    {
        services
            .AddGrpcCommunication(configuration, typeAdapterConfig);

        return services;
    }
}
