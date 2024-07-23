namespace PetsOnTrail.Communication.gRPC.Models;

public sealed record GetActionsResponse
{
    public IEnumerable<ActionDto> Actions { get; init; } = new List<ActionDto>(0);

    public sealed record ActionDto
    {
        public Guid Id { get; init; }
        public Guid TypeId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTimeOffset? From { get; init; }
        public DateTimeOffset? To { get; init; }
        public string Country { get; init; }
        public string Province {  get; init; }
        public string City { get; init; }
        public string PostalCode { get; init; }
        public string Address { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
