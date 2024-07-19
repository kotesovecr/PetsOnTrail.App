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
            Start = DateTimeOffset.Now,
            Finish = DateTimeOffset.Now.AddHours(1),
            Races = new List<RaceDto>
            {
                new RaceDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Race 1",
                    Categories = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Category 1",
                            Description = "Description 1",
                            Results = new List<ResultDto>
                            {
                                new ResultDto
                                {
                                    Id = Guid.NewGuid(),
                                    RaceId = Guid.NewGuid(),
                                    CategoryId = Guid.NewGuid(),
                                    FirstName = "First Name 1",
                                    LastName = "Last Name 1",
                                    Start = DateTimeOffset.Now.AddHours(1),
                                    Finish = DateTimeOffset.Now.AddHours(2),
                                    Checkpoints = new List<CheckpointDto>
                                    {
                                        new CheckpointDto
                                        {
                                            Id = Guid.NewGuid(),
                                            Time = DateTimeOffset.Now
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
            Start = DateTimeOffset.Now,
            Finish = DateTimeOffset.Now.AddHours(1),
            Races = new List<RaceDto>
            {
                new RaceDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Race 2",
                    Categories = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Category 2",
                            Description = "Description 2",
                            Results = new List<ResultDto>
                            {
                                new ResultDto
                                {
                                    Id = Guid.NewGuid(),
                                    RaceId = Guid.NewGuid(),
                                    CategoryId = Guid.NewGuid(),
                                    FirstName = "First Name 2",
                                    LastName = "Last Name 2",
                                    Start = DateTimeOffset.Now.AddHours(3),
                                    Finish = DateTimeOffset.Now.AddHours(4),
                                    Checkpoints = new List<CheckpointDto>
                                    {
                                        new CheckpointDto
                                        {
                                            Id = Guid.NewGuid(),
                                            Time = DateTimeOffset.Now
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
