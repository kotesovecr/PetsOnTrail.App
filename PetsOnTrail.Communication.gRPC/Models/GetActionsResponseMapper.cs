using Mapster;

namespace PetsOnTrail.Communication.gRPC.Models;

internal static class GetActionsResponseMapper
{
    public static TypeAdapterConfig AddGetActionsResponse(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetActions.GetActionsResponse, GetActionsResponse>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetActions.ActionDto, GetActionsResponse.ActionDto>();

        return typeAdapterConfig;
    }
}
