using AutoMapper;
using ToDo.Core.Exeption;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class AssignmentServices : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public AssignmentServices(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }

    public AssignmentServices(IMapper mapper, IAssignmentRepository assignmentRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<AssignmentDTO> Create(AssignmentDTO assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();

        var assignementCreated = await _assignmentRepository.Create(assignment);

        return _mapper.Map<AssignmentDTO>(assignmentDto);
    }

    public async Task<List<AssignmentDTO>> GetAll()
    {
        var allAssignments = await _assignmentRepository.GetAll();

        return _mapper.Map<List<AssignmentDTO>>(allAssignments);
    }

    public async Task<AssignmentDTO> GetById(int id)
    {
        var assignment = await _assignmentRepository.GetById(id);

        return _mapper.Map<AssignmentDTO>(assignment);
    }

    public async Task<AssignmentDTO> Update(AssignmentDTO assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.GetById(assignmentDto.Id);

        if (assignmentExists == null)
        {
            throw new DomainExeption("Não existe uma task com o id informado");
        }

        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();

        var assignmentUpdated = await _assignmentRepository.Update(assignment);

        return _mapper.Map<AssignmentDTO>(assignmentDto);
    }

    public async Task MarkAsDone(int id)
    {
        var assignment = await _assignmentRepository.GetById(id);
        
        assignment.SetConclued();

        await _assignmentRepository.Update(assignment);
    }

    public async Task MarkAsUndone(int id)
    {
        var assignment = await _assignmentRepository.GetById(id);
        
        assignment.SetUnconclued();

        await _assignmentRepository.Update(assignment);
    }

    public async Task Delete(int id)
    {
        await _assignmentRepository.Delete(id);
    }
}