namespace PetsOnTrail.Communication.gRPC.Models;

public sealed record GetActionResponse
{
    public Guid Id { get; init; }
    public DateTimeOffset Created { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string ContactMail { get; init; }
    public TermDto Term { get; init; }
    public AddressDto Address { get; init; }
    public IEnumerable<RaceDto> Races { get; init; }
    public ActionSaleDto Sale { get; init; }
    public Guid TypeId { get; init; }
    public IEnumerable<Guid> DetailsCanSee { get; init; }
    public IEnumerable<Guid> ResultsCanEdit { get; init; }
    public IEnumerable<Guid> CompetitorsCanEdit { get; init; }
    public IEnumerable<Guid> ActionCanEdit { get; init; }
}

public sealed record CheckpointDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public LatLngDto Position { get; init; }
}

public sealed record RaceDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public double Distance { get; init; }
    public double Incline { get; init; }
    public DateTimeOffset? EnteringFrom { get; init; }
    public DateTimeOffset? EnteringTo { get; init; }
    public int MaxNumberOfCompetitors { get; init; }
    public DateTimeOffset? Begin { get; init; }
    public DateTimeOffset? End { get; init; }
    public IEnumerable<CategoryDto> Categories { get; init; }
    public IEnumerable<PaymentDefinitionDto> Payments { get; init; }
    public LimitsDto Limits { get; init; }
    public IEnumerable<CheckpointDto> Checkpoints { get; init; }
}

public sealed record CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public IEnumerable<RacerDto> Racers { get; init; }
}

public enum RaceState
{
    NotSpecified = 0,
    NotStarted = 1,
    Started = 2,
    Finished = 3,
    DidNotFinished = 4,
    Disqualified = 5
}

public sealed record RacerDto
{
    public Guid Id { get; init; }
    public Guid CompetitorId { get; init; }
    public string CheckpointData { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Phone { get; init; }
    public string Email { get; init; }
    public IEnumerable<PetDto> Pets { get; init; }
    public DateTimeOffset? Start { get; init; }
    public DateTimeOffset? Finish { get; init; }
    public RaceState State { get; init; }
    public bool Accepted { get; init; }
    public DateTimeOffset? AcceptedDate { get; init; }
    public bool Payed { get; init; }
    public DateTimeOffset? PayedDate { get; init; }
    public IEnumerable<PaymentDto> Payments { get;init; }
    public IEnumerable<NoteDto> Notes { get; init; }
    public RequestedPaymentsDto RequestedPayments { get; init; }
    public IEnumerable<MerchandizeItemDto> Merchandize { get; init; }
    public AddressDto Address { get; init; }
    public IEnumerable<PassedCheckpointDto> PassedCheckpoints { get; init; }
}

public sealed record PassedCheckpointDto
{
    public Guid Id { get; init; }
    public DateTimeOffset? Passed { get; init; }
    public LatLngDto Position { get; init; }
}

public sealed record NoteDto
{
    public DateTimeOffset? Time { get; init; }
    public string Text { get; init; }
}

public sealed record PetDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Name { get; init; }
    public string Kennel { get; init; }
    public string Pedigree { get; init; }
    public string Chip { get; init; }
    public DateTimeOffset? Birthday { get; init; }
    public string UriToPhoto { get; init; }
    public string Contact { get; init; }
}

public sealed record RequestedPaymentsDto
{
  public string VariableNumber { get; init; }
  public double Sum { get; init; }
  public IEnumerable<RequestedPaymentItem> Items { get; init; }
}

public sealed record RequestedPaymentItem
{
    public string Name { get; init; }
    public double Price { get; init; }
    public string Currency { get; init; }
}

public sealed record PaymentDto
{
    public Guid Id { get; init; }
    public DateTimeOffset? Date { get; init; }
    public double Amount { get; init; }
    public string Currency { get; init; }
    public string BankAccount { get; init; }
    public string Note { get; init; }
}

public sealed record MerchandizeItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public string Currency { get; init; }
    public string Variant { get; init; }
    public string Size { get; init; }
    public string Color { get; init; }
    public string Note { get; init; }
    public int Count { get; init; }
}

public sealed record PaymentDefinitionDto
{
    public Guid Id { get; init; }
    public string BankAccount { get; init; }
    public DateTimeOffset? From { get; init; }
    public DateTimeOffset? To { get; init; }
    public double Price { get; init; }
    public string Currency { get; init; }
}

public sealed record LimitsDto
{
    public int MinimalAgeOfRacerInDayes { get; init; }
    public int MinimalAgeOfThePetInDayes { get; init; }
    public bool WithPets { get; init; }
}

public sealed record TermDto
{
    public DateTimeOffset? From { get; init; }
    public DateTimeOffset? To { get; init; }
}

public sealed record AddressDto
{
    public string Country { get; init; }
    public string Region { get; init; }
    public string ZipCode { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public LatLngDto Position { get; init; }
}

public sealed record ActionSaleDto
{
    public IEnumerable<ActionSaleItemDto> Items { get; init; }
}

public sealed record ActionSaleItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public string Currency { get; init; }
    public IEnumerable<string> Variants { get; init; }
    public IEnumerable<string> Sizes { get; init; }
    public IEnumerable<string> Colors { get; init; }
}

public record LatLngDto
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}