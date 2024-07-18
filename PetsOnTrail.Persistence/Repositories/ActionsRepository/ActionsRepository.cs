
using Blazored.LocalStorage;
using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

internal class ActionsRepository : IActionsRepository
{
    private const string _prefix = "actions_";
    private readonly ILocalStorageService _localStorage;

    public ActionsRepository(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<ActionDto> AddOrUpdateCheckpointOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, Guid checkpointId, DateTimeOffset? time, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Results
                .FirstOrDefault(result => result.Id == resultId);

        if (result != null && result.Checkpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId) != null)
        {
            result.Checkpoints.Remove(result.Checkpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId)!);
        }

        result!.Checkpoints.Add(new ResultDto.CheckpointDto { Id = checkpointId, Time = time });

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateFinishOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? finish, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Results
                .FirstOrDefault(result => result.Id == resultId);

        if (result != null)
            result!.Finish = finish;

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultDto result, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var category = action?.Races.FirstOrDefault(race => race.Id == raceId)?.Categories.FirstOrDefault(category => category.Id == categoryId);
        if (category != null && category.Results.FirstOrDefault(r => r.Id == result.Id) != null)
        { 
            category.Results.Remove(category.Results.FirstOrDefault(r => r.Id == result.Id)!);
        }

        category?.Results.Add(result);

        var response = await UpdateActionAsync(action!, cancellationToken);

        return response;
    }

    public async Task<ActionDto> AddOrUpdateStartOfResultAsync(Guid actionId, Guid raceId, Guid categoryId, Guid resultId, DateTimeOffset? start, CancellationToken cancellationToken)
    {
        var action = await GetActionAsync(actionId, cancellationToken);

        var result = action?.Races
                .FirstOrDefault(race => race.Id == raceId)?.Categories
                .FirstOrDefault(category => category.Id == categoryId)?.Results
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
        return await _localStorage.GetItemAsync<ActionDto>($"{_prefix}{id}", cancellationToken);
    }

    public async Task<IEnumerable<ActionDto>> GetActionsAsync(CancellationToken cancellationToken)
    {
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
