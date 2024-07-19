namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record ResultDto
{
    public Guid Id { get; set; }
    public Guid ActionId { get; set; }
    public Guid RaceId { get; set; }
    public Guid CategoryId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTimeOffset? Start { get; set; }
    public IList<CheckpointDto> Checkpoints { get; set; } = new List<CheckpointDto>();
    public DateTimeOffset? Finish { get; set; }
    public string Note { get; set; } = string.Empty;
}
