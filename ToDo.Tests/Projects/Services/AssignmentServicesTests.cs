using AutoMapper;
using Bogus;
using FluentAssertions;
using Moq;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;
using ToDo.Tests.Configuration;
using ToDo.Tests.Fixtures;
using Xunit;

namespace ToDo.Tests.Projects.Services;

public class AssignmentServicesTests
    {
        private readonly int _assignmentId = new Randomizer().Int(2, 3);
        private readonly AssignmentServices _assignmentServices;
        private readonly IMapper _mapper;
        private readonly IAssignmentService _sut;
    
        //moks
        private readonly Mock<IAssignmentRepository> _assignmentRepositoryMock = new();

        private readonly Faker<Assignment> _assignmentFaker;
        
        //implementar a cripto

        public AssignmentServicesTests()
        {
            _assignmentServices =
                new AssignmentServices(AutomapperConfigutation.CreateMapper(), _assignmentRepositoryMock.Object);
            
            _mapper = AutomapperConfigutation.CreateMapper();
            _assignmentRepositoryMock = new Mock<IAssignmentRepository>();
        }
        
        [Fact]
        public async Task CreateAssignment_WhenIsValidAssignment_ReturnAssignment()
        {
            //arrange
            var assignmentToCreate = AssignmentFixture.CreateValidAssignmentDto();

            //Act
            var assignmentCreated = await _assignmentServices.Create(assignmentToCreate);
            
            
            //assert
            assignmentCreated.Should().NotBeNull();
        }
    }