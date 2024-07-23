using MapsterMapper;
using PetsOnTrail.Communication.gRPC.Interfaces;
using PetsOnTrail.Communication.gRPC.Models;
using Protos.Actions.GetAction;
using Protos.Actions.GetActions;
using static Protos.Actions.Actions;

namespace PetsOnTrail.Communication.gRPC.Implementations;

internal class ActionsRepository : IActionsRepository
{
    private readonly ActionsClient _actionsClient;
    private readonly IMapper _mapper;

    public ActionsRepository(ActionsClient actionsClient, IMapper mapper)
    {
        _actionsClient = actionsClient;
        _mapper = mapper;
    }

    public async Task<Models.GetActionResponse> GetActionAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _actionsClient.getActionAsync(new GetActionRequest { Id = id.ToString() }, cancellationToken: cancellationToken);

        return _mapper.Map<Models.GetActionResponse>(response);
    }

    public async Task<Models.GetActionsResponse> GetActionsAsync(IEnumerable<Guid> typeIds, CancellationToken cancellationToken)
    {
        var response = await _actionsClient.getActionsAsync(new GetActionsRequest { TypeIds = { typeIds.Select(id => id.ToString()) } }, cancellationToken: cancellationToken);

        return _mapper.Map<Models.GetActionsResponse>(response);
    }
}
