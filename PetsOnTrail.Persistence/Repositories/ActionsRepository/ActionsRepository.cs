using Blazored.LocalStorage;
using MapsterMapper;
using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

internal class ActionsRepository : IActionsRepository
{
    private const string _prefix = "actions_";
    private readonly ILocalStorageService _localStorage;
    private readonly PetsOnTrail.Communication.gRPC.Interfaces.IActionsRepository _actionsRemoteRepository;
    private readonly IMapper _mapper;

    public ActionsRepository(ILocalStorageService localStorage, PetsOnTrail.Communication.gRPC.Interfaces.IActionsRepository actionsRemoteRepository, IMapper mapper)
    {
        _localStorage = localStorage;
        _actionsRemoteRepository = actionsRemoteRepository;
        _mapper = mapper;

        //// Seed data
        //foreach (var action in TestingData.GetActions())
        //{
        //    _localStorage.SetItemAsync($"{_prefix}{action.Id}", action, CancellationToken.None);
        //}
    }

    public async Task<ActionDto> AddOrUpdateCheckpointOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, Guid checkpointId, DateTimeOffset? time, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Racers
                .FirstOrDefault(result => result.Id == resultId);

        if (result != null && result.PassedCheckpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId) != null)
        {
            result.PassedCheckpoints.Remove(result.PassedCheckpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId)!);
        }

        result!.PassedCheckpoints.Add(new ActionDto.PassedCheckpointDto { Id = checkpointId, Passed = time ?? DateTimeOffset.UtcNow });

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateFinishOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? finish, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Racers
                .FirstOrDefault(result => result.Id == resultId);

        if (result != null)
            result!.Finish = finish;

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateResultAsync(Guid actionId, Guid raceId, Guid categoryId, ActionDto.RacerDto racer, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var category = action?.Races.FirstOrDefault(race => race.Id == raceId)?.Categories.FirstOrDefault(category => category.Id == categoryId);
        if (category != null && category.Racers.FirstOrDefault(r => r.Id == racer.Id) != null)
        { 
            category.Racers.Remove(category.Racers.FirstOrDefault(r => r.Id == racer.Id)!);
        }

        category?.Racers.Add(racer);

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateStartOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? start, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Racers
                .FirstOrDefault(result => result.Id == resultId);

        if (result != null)
            result!.Start = start;

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> CreateActionAsync(ActionDto action, CancellationToken cancellationToken)
    {
        if (action.Id == Guid.Empty)
        {
            action.Id = Guid.NewGuid();
        }

        await _localStorage.SetItemAsync($"{_prefix}{action.Id}", action, cancellationToken);

        return action;
    }

    public async Task DeleteActionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _localStorage.RemoveItemAsync($"{_prefix}{id}", cancellationToken);
    }

    public async Task<ActionDto?> GetActionAsync(Guid id, CancellationToken cancellationToken)
    {
        var remoteActionData = await _actionsRemoteRepository.GetActionAsync(id, cancellationToken);
        if (remoteActionData != null)
        {
            await _localStorage.SetItemAsync($"{_prefix}{id}", _mapper.Map<ActionDto>(remoteActionData), cancellationToken);
        }

        return await _localStorage.GetItemAsync<ActionDto>($"{_prefix}{id}", cancellationToken);
    }

    public async Task<IEnumerable<ActionDto>> GetActionsAsync(IEnumerable<Guid> typeIds, CancellationToken cancellationToken)
    {
        var remoteActionsData = await _actionsRemoteRepository.GetActionsAsync(typeIds, cancellationToken);
        
        foreach (var action in remoteActionsData.Actions)
        {
            // only add new one. If already exists, do not add
            if (await _localStorage.ContainKeyAsync($"{_prefix}{action.Id}") == false)
                await _localStorage.SetItemAsync($"{_prefix}{action.Id}", _mapper.Map<ActionDto>(action), cancellationToken);
        }

        var keys = await _localStorage.KeysAsync(cancellationToken);
        var actionKeys = keys.Where(key => key.StartsWith(_prefix));

        var actions = new List<ActionDto>();
        foreach (var key in actionKeys)
        {
            var action = await _localStorage.GetItemAsync<ActionDto>(key, cancellationToken);
            if (action != null)
            {
                actions.Add(action);
            }
        }

        return actions;
    }

    public async Task<ActionDto> UpdateActionAsync(ActionDto action, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync($"{_prefix}{action.Id}", action, cancellationToken);

        return action;
    }
}
