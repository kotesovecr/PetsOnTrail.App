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

        typeAdapterConfig.NewConfig<GetActionsResponse.ActionDto, ActionDto>()
            .MapWith(s => new ActionDto
            {
                Id = s.Id,
                TypeId = s.TypeId,
                Name = s.Name,
                Description = s.Description,
                Term = new ActionDto.TermDto
                {
                    From = s.From,
                    To = s.To
                },
                Address = new ActionDto.AddressDto
                {
                    Country = s.Country,
                    City = s.City,
                    Street = s.Address,
                    Position = new ActionDto.LatLngDto
                    {
                        Latitude = s.Latitude,
                        Longitude = s.Longitude
                    }
                }
            });

        return typeAdapterConfig;
    }
}
