using Mapster;
using static Google.Rpc.Context.AttributeContext.Types;

namespace PetsOnTrail.Communication.gRPC.Models;

internal static class GetActionResponseMapper
{
    public static TypeAdapterConfig AddGetActionResponse(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionResponse, GetActionResponse>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.AddressDto, AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleDto, ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleItemDto, ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CategoryDto, CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CheckpointDto, CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.LimitsDto, LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.MerchandizeItemDto, MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.NoteDto, NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PetDto, PetDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PassedCheckpointDto, PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDefinitionDto, PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentsDto, RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentItem, RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDto, PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RaceDto, RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RacerDto, RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.TermDto, TermDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, LatLngDto>()
            .MapWith(s => new LatLngDto { Latitude = s.Latitude, Longitude = s.Longitude });

        return typeAdapterConfig;
    }
}
