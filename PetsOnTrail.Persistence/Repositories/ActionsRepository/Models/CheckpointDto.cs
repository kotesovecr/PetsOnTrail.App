namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record CheckpointDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
}
