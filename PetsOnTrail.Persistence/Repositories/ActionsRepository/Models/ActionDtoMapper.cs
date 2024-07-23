using Mapster;
using PetsOnTrail.Communication.gRPC.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

internal static class ActionDtoMapper
{
    public static TypeAdapterConfig AddGetActionResponse(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetActionResponse, ActionDto>();
        typeAdapterConfig.NewConfig<AddressDto, AddressDto>();
        typeAdapterConfig.NewConfig<ActionSaleDto, ActionSaleDto>();
        typeAdapterConfig.NewConfig<ActionSaleItemDto, ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<CategoryDto, CategoryDto>();
        typeAdapterConfig.NewConfig<CheckpointDto, CheckpointDto>();
        typeAdapterConfig.NewConfig<LimitsDto, LimitsDto>();
        typeAdapterConfig.NewConfig<MerchandizeItemDto, MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<NoteDto, NoteDto>();
        typeAdapterConfig.NewConfig<PetDto, PetDto>();
        typeAdapterConfig.NewConfig<PassedCheckpointDto, PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<PaymentDefinitionDto, PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<PaymentDto, PaymentDto>();
        typeAdapterConfig.NewConfig<RaceDto, RaceDto>();
        typeAdapterConfig.NewConfig<RacerDto, RacerDto>();
        typeAdapterConfig.NewConfig<TermDto, TermDto>();

        return typeAdapterConfig;
    }
}
