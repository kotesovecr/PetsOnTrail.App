using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PetsOnTrail.App;
using PetsOnTrail.Authentication;
using PetsOnTrail.Persistence;
using PetsOnTrail.Translation;
using PetsOnTrail.Communication;
using Mapster;
using Google.Protobuf.Collections;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var typeAdapterConfig = new TypeAdapterConfig
{
    RequireDestinationMemberSource = true,
    RequireExplicitMapping = true,
    Default =
            {
                Settings =
                {
                    UseDestinationValues =
                    {
                        (member => member.SetterModifier == AccessModifier.None &&
                                   member.Type.IsGenericType &&
                                   member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>))
                    }
                }
            }
};

builder.Services
    .AddHttpClient()
    .AddAuthentication(builder.Configuration)
    .AddPersistence()
    .AddTranslation(builder.HostEnvironment.BaseAddress)
    .AddCommunication(builder.Configuration, typeAdapterConfig)
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddSingleton(typeAdapterConfig);

await builder.Build().RunAsync();
