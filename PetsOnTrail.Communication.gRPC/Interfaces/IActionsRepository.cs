using PetsOnTrail.Communication.gRPC.Models;

namespace PetsOnTrail.Communication.gRPC.Interfaces;

public interface IActionsRepository
{
    Task<GetActionResponse> GetActionAsync(Guid id, CancellationToken cancellationToken);
}
