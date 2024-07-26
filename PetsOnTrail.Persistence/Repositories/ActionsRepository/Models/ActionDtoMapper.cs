using Mapster;
using PetsOnTrail.Communication.gRPC.Models;
using static Google.Rpc.Context.AttributeContext.Types;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

internal static class ActionDtoMapper
{
    public static TypeAdapterConfig AddGetActionResponse(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetActionResponse, ActionDto>();
        typeAdapterConfig.NewConfig<AddressDto, ActionDto.AddressDto>();
        typeAdapterConfig.NewConfig<ActionSaleDto, ActionDto.ActionSaleDto>();
        typeAdapterConfig.NewConfig<ActionSaleItemDto, ActionDto.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<CategoryDto, ActionDto.CategoryDto>();
        typeAdapterConfig.NewConfig<CheckpointDto, ActionDto.CheckpointDto>();
        typeAdapterConfig.NewConfig<LimitsDto, ActionDto.LimitsDto>();
        typeAdapterConfig.NewConfig<MerchandizeItemDto, ActionDto.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<NoteDto, ActionDto.NoteDto>();
        typeAdapterConfig.NewConfig<PetDto, ActionDto.PetDto>();
        typeAdapterConfig.NewConfig<PassedCheckpointDto, ActionDto.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<PaymentDefinitionDto, ActionDto.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<PaymentDto, ActionDto.PaymentDto>();
        typeAdapterConfig.NewConfig<RaceDto, ActionDto.RaceDto>();
        typeAdapterConfig.NewConfig<RacerDto, ActionDto.RacerDto>();
        typeAdapterConfig.NewConfig<TermDto, ActionDto.TermDto>();
        typeAdapterConfig.NewConfig<LatLngDto, ActionDto.LatLngDto>();
        typeAdapterConfig.NewConfig<RequestedPaymentsDto, ActionDto.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<RequestedPaymentItem, ActionDto.RequestedPaymentItem>();

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
