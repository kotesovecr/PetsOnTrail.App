using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;

namespace PetsOnTrail.Translation;

public static class DICompositor
{
    public static IServiceCollection AddTranslation(this IServiceCollection services, string baseUri)
    {
        services
            .AddHttpClient<TranslationApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

        services
            .AddScoped<ITranslationService, TranslationService>();

        return services;
    }
}
