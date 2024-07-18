namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record RaceDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public IList<CheckpointDto> Checkpoints { get; init; } = new List<CheckpointDto>();
    public IList<CategoryDto> Categories { get; init; } = new List<CategoryDto>();
}
