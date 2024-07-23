using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

public interface IActionsRepository
{
    Task<IEnumerable<ActionDto>> GetActionsAsync(IEnumerable<Guid> typeIds, CancellationToken cancellationToken);
    Task<ActionDto?> GetActionAsync(Guid id, CancellationToken cancellationToken);
    Task<ActionDto> CreateActionAsync(ActionDto action, CancellationToken cancellationToken);
    Task<ActionDto> UpdateActionAsync(ActionDto action, CancellationToken cancellationToken);
    Task DeleteActionAsync(Guid id, CancellationToken cancellationToken);

    Task<ActionDto> AddOrUpdateResultAsync(Guid actionId, Guid raceId, Guid categoryId, ActionDto.RacerDto result, CancellationToken cancellationToken);
    Task<ActionDto> AddOrUpdateStartOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? start, CancellationToken cancellationToken);
    Task<ActionDto> AddOrUpdateFinishOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? finish, CancellationToken cancellationToken);
    Task<ActionDto> AddOrUpdateCheckpointOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, Guid checkpointId, DateTimeOffset? time, CancellationToken cancellationToken);
}
