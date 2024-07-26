namespace PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

public sealed record ActionDto
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ContactMail { get; set; }
    public TermDto Term { get; set; }
    public AddressDto Address { get; set; }
    public List<RaceDto> Races { get; set; } = new();
    public ActionSaleDto Sale { get; set; }
    public Guid TypeId { get; set; }
    public List<Guid> DetailsCanSee { get; set; } = new();
    public List<Guid> ResultsCanEdit { get; set; } = new();
    public List<Guid> CompetitorsCanEdit { get; set; } = new();
    public List<Guid> ActionCanEdit { get; set; } = new();

    public sealed record CheckpointDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LatLngDto Position { get; set; }
    }

    public sealed record RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Incline { get; set; }
        public DateTimeOffset? EnteringFrom { get; set; }
        public DateTimeOffset? EnteringTo { get; set; }
        public int MaxNumberOfCompetitors { get; set; }
        public DateTimeOffset? Begin { get; set; }
        public DateTimeOffset? End { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
        public List<PaymentDefinitionDto> Payments { get; set; } = new();
        public LimitsDto Limits { get; set; }
        public List<CheckpointDto> Checkpoints { get; set; } = new();
    }

    public sealed record CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RacerDto> Racers { get; set; } = new();
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
        public Guid Id { get; set; }
        public Guid CompetitorId { get; set; }
        public string CheckpointData { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<PetDto> Pets { get; set; } = new();
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? Finish { get; set; }
        public RaceState State { get; set; }
        public bool Accepted { get; set; }
        public DateTimeOffset? AcceptedDate { get; set; }
        public bool Payed { get; set; }
        public DateTimeOffset? PayedDate { get; set; }
        public List<PaymentDto> Payments { get; set; } = new();
        public List<NoteDto> Notes { get; set; } = new();
        public RequestedPaymentsDto RequestedPayments { get; set; }
        public List<MerchandizeItemDto> Merchandize { get; set; } = new();
        public AddressDto Address { get; set; }
        public List<PassedCheckpointDto> PassedCheckpoints { get; set; } = new();
    }

    public sealed record PassedCheckpointDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset? Passed { get; set; }
        public LatLngDto Position { get; set; }
    }

    public sealed record NoteDto
    {
        public DateTimeOffset? Time { get; set; }
        public string Text { get; set; }
    }

    public sealed record PetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Kennel { get; set; }
        public string Pedigree { get; set; }
        public string Chip { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string UriToPhoto { get; set; }
        public string Contact { get; set; }
    }

    public sealed record RequestedPaymentsDto
    {
        public string VariableNumber { get; set; }
        public double Sum { get; set; }
        public List<RequestedPaymentItem> Items { get; set; } = new();
    }

    public sealed record RequestedPaymentItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }

    public sealed record PaymentDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset? Date { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string BankAccount { get; set; }
        public string Note { get; set; }
    }

    public sealed record MerchandizeItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Variant { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }
        public int Count { get; set; }
    }

    public sealed record PaymentDefinitionDto
    {
        public Guid Id { get; set; }
        public string BankAccount { get; set; }
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }

    public sealed record LimitsDto
    {
        public int MinimalAgeOfRacerInDayes { get; set; }
        public int MinimalAgeOfThePetInDayes { get; set; }
        public bool WithPets { get; set; }
    }

    public sealed record TermDto
    {
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
    }

    public sealed record AddressDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public LatLngDto Position { get; set; }
    }

    public sealed record ActionSaleDto
    {
        public List<ActionSaleItemDto> Items { get; set; } = new();
    }

    public sealed record ActionSaleItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public List<string> Variants { get; set; } = new();
        public List<string> Sizes { get; set; } = new();
        public List<string> Colors { get; set; } = new();
    }

    public record LatLngDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

