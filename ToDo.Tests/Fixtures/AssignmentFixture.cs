using Bogus;
using Bogus.DataSets;
using ToDo.Domain.Entities;
using ToDo.Services.DTOs;

namespace ToDo.Tests.Fixtures;

public class AssignmentFixture
{
    public static AssignmentDTO CreateValidAssignmentDto()
    {
        return new AssignmentDTO
        {
            UserId = new Randomizer().Int(1, 1000),
            Id = new Randomizer().Int(1, 1000),
            Description = new Lorem().Text(),
            TodoId = new Randomizer().Int(1, 1000),
            Conclued = false,
            ConcluedAt = DateTime.Now,
            DeadLine = DateTime.Now
        };
    }
}