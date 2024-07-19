using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Authentication.Providers;

namespace PetsOnTrail.Authentication;

public static class DICompositor
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, WebAssemblyHostConfiguration configuration)
    {
        services
            .AddOidcAuthentication(options =>
            {
                configuration.Bind("OIDC", options.ProviderOptions);
            });

        services
            .AddScoped<ITokenProvider, TokenProvider>()
            .AddScoped<TokenStorage>();

        return services;
    }
}
