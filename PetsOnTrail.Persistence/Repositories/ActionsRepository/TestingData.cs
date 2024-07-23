using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.Persistence.Repositories.ActionsRepository;

internal static class TestingData
{
    public static IEnumerable<ActionDto> GetActions() => new List<ActionDto>
    {
        new ActionDto
        {
            Id = Guid.NewGuid(),
            Name = "Action 1",
            Description = "Description 1",
            Term = new ActionDto.TermDto
            {
                From = DateTimeOffset.Now,
                To = DateTimeOffset.Now.AddHours(1)
            },            
            Races = new List<ActionDto.RaceDto>
            {
                new ActionDto.RaceDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Race 1",
                    Categories = new List<ActionDto.CategoryDto>
                    {
                        new ActionDto.CategoryDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Category 1",
                            Description = "Description 1",
                            Racers = new List<ActionDto.RacerDto>
                            {
                                new ActionDto.RacerDto
                                {
                                    Id = Guid.NewGuid(),
                                    FirstName = "First Name 1",
                                    LastName = "Last Name 1",
                                    Start = DateTimeOffset.Now.AddHours(1),
                                    Finish = DateTimeOffset.Now.AddHours(2),
                                    PassedCheckpoints = new List<ActionDto.PassedCheckpointDto>
                                    {
                                        new ActionDto.PassedCheckpointDto
                                        {
                                            Id = Guid.NewGuid(),
                                            Passed = DateTimeOffset.Now
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        },
        new ActionDto
        {
            Id = Guid.NewGuid(),
            Name = "Action 2",
            Description = "Description 2",
            Term = new ActionDto.TermDto
            {
                From = DateTimeOffset.Now,
                To = DateTimeOffset.Now.AddHours(1)
            },
            Races = new List<ActionDto.RaceDto>
            {
                new ActionDto.RaceDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Race 2",
                    Categories = new List<ActionDto.CategoryDto>
                    {
                        new ActionDto.CategoryDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Category 2",
                            Description = "Description 2",
                            Racers = new List<ActionDto.RacerDto>
                            {
                                new ActionDto.RacerDto
                                {
                                    Id = Guid.NewGuid(),
                                    FirstName = "First Name 2",
                                    LastName = "Last Name 2",
                                    Start = DateTimeOffset.Now.AddHours(3),
                                    Finish = DateTimeOffset.Now.AddHours(4),
                                    PassedCheckpoints = new List<ActionDto.PassedCheckpointDto>
                                    {
                                        new ActionDto.PassedCheckpointDto
                                        {
                                            Id = Guid.NewGuid(),
                                            Passed = DateTimeOffset.Now
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    };
}
