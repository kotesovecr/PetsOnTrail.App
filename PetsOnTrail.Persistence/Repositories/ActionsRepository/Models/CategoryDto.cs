namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public IList<ResultDto> Results { get; init; } = new List<ResultDto>();
}
