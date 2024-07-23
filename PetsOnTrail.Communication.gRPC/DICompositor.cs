using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Mapster;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Communication.gRPC.Extensions;
using PetsOnTrail.Communication.gRPC.Implementations;
using PetsOnTrail.Communication.gRPC.Interfaces;
using PetsOnTrail.Communication.gRPC.Models;

namespace PetsOnTrail.Communication.gRPC;

public static class DICompositor
{
    public static IServiceCollection AddGrpcCommunication(this IServiceCollection services, WebAssemblyHostConfiguration configuration, TypeAdapterConfig typeAdapterConfig)
    {
        services
            .AddSingleton(services =>
            {
                var baseUri = configuration["GrpcServerUri"];

                var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });

                return channel;
            })
            .AddScoped<IGrpcCommunicator, GrpcCommunicator>()
            .AddScoped<IActionsRepository, ActionsRepository>();

        services
            .AddAuthorizedGrpcOverWebClient<Protos.UserProfiles.UserProfiles.UserProfilesClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Actions.Actions.ActionsClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Entries.Entries.EntriesClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.ActionRights.ActionRights.ActionRightsClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Pets.Pets.PetsClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Results.Results.ResultsClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.LiveUpdatesSubscription.LiveUpdatesSubscription.LiveUpdatesSubscriptionClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Checkpoints.Checkpoints.CheckpointsClient>(configuration["GrpcServerUri"])
            .AddAuthorizedGrpcOverWebClient<Protos.Activities.Activities.ActivitiesClient>(configuration["GrpcServerUri"]);

        typeAdapterConfig
            .AddGetActionResponse()
            .AddGetActionsResponse();

        typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset?>().Map(d => d, s => s.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset>().Map(d => d, s => s.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<DateTimeOffset, Google.Type.DateTime>().Map(d => d, s => s.ToGoogleDateTime());
        typeAdapterConfig.NewConfig<DateTimeOffset?, Google.Type.DateTime>().Map(d => d, s => s.ToGoogleDateTime());
        typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTime>().Map(d => d, s => s.ToDateTimeOffset().Value.DateTime);

        typeAdapterConfig.NewConfig<Google.Type.Interval, Google.Type.Interval>();
        typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Timestamp, Google.Protobuf.WellKnownTypes.Timestamp>();
        typeAdapterConfig.NewConfig<Google.Type.DateTime, Google.Type.DateTime>();
        typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Duration, Google.Protobuf.WellKnownTypes.Duration>();
        typeAdapterConfig.NewConfig<Google.Type.TimeZone, Google.Type.TimeZone>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, Google.Type.LatLng>();


        return services;
    }
}
