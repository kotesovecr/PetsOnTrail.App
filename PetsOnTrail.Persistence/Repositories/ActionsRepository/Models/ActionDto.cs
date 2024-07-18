namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record ActionDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;

    public IList<RaceDto> Races { get; set; } = new List<RaceDto>();
}
