using Grpc.Net.Client.Web;

using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Authentication.Providers;

namespace PetsOnTrail.Communication.gRPC.Extensions;

public static class AuthorizedGrpcClientExtension
{
    public static IServiceCollection AddAuthorizedGrpcOverWebClient<T>(this IServiceCollection serviceCollection, string uri) where T : class
    {
        serviceCollection
            .AddGrpcClient<T>(o =>
            {
                o.Address = new Uri(uri);
            })
            .AddCallCredentials(async (context, metadata, serviceProvider) =>
            {
                var provider = serviceProvider.GetRequiredService<ITokenProvider>();
                var token = await provider.GetTokenAsync();
                metadata.Add("Authorization", $"Bearer {token}");
            })
            .ConfigureChannel(o =>
            {
                o.HttpHandler = new GrpcWebHandler(new HttpClientHandler());
                o.UnsafeUseInsecureChannelCallCredentials = true;
            });

        return serviceCollection;
    }

    public static IServiceCollection AddAuthorizedGrpcClient<T>(this IServiceCollection serviceCollection, string uri) where T : class
    {
        serviceCollection
            .AddGrpcClient<T>(o =>
            {
                o.Address = new Uri(uri);
            })
            .AddCallCredentials(async (context, metadata, serviceProvider) =>
            {
                var provider = serviceProvider.GetRequiredService<ITokenProvider>();
                var token = await provider.GetTokenAsync();

                if (string.IsNullOrWhiteSpace(token) == false)
                    metadata.Add("Authorization", $"Bearer {token ?? string.Empty}");
            })
            .ConfigureChannel(o =>
            {
                o.HttpHandler = new GrpcWebHandler(new HttpClientHandler());
                o.UnsafeUseInsecureChannelCallCredentials = true;
            });

        return serviceCollection;
    }
}
