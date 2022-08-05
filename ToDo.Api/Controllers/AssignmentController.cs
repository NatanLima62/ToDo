using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Utilities;
using ToDo.Api.ViewModels.AssignmentViewModel;
using ToDo.Api.ViewModels.ResultViewModel;
using ToDo.Core.Exeption;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Api.Controllers;

[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [Route("api/v1/assignments/create")]
    public async Task<IActionResult> Create([FromBody] CreateAssignmentViewModel createAssignmentViewModel)
    {
        try
        {
            var assignment = _mapper.Map<AssignmentDTO>(createAssignmentViewModel);

            var assignmentCreated = await _assignmentService.Create(assignment);

            return Ok(new ResultViewModel
            {
                Message = "Task criada com sucesso",
                Sucess = true,
                Data = assignmentCreated
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Authorize]
    [Route("api/v1/assignments/get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allAssignments = await _assignmentService.GetAll();

            return Ok(new ResultViewModel
            {
                Message = "Tasks encontradas com sucesso",
                Sucess = true,
                Data = allAssignments
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/assignments/get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _assignmentService.GetById(id);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Não foi encontrada nenhuma task com o id informado",
                    Sucess = false,
                    Data = null
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Task encontrada com sucesso",
                Sucess = true,
                Data = user
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpPut]
    [Authorize]
    [Route("/api/v1/assignments/Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAssignmentViewModel updateAssignmentViewModel)
    {
        try
        {
            var user = _mapper.Map<AssignmentDTO>(updateAssignmentViewModel);

            var userUpdated = await _assignmentService.Update(user);

            return Ok(new ResultViewModel
            {
                Message = "Task atualizada com sucesso",
                Sucess = true,
                Data = userUpdated
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500,Responses.ApplicationErrorMessage());
        }
    }

    [HttpDelete]
    [Authorize]
    [Route("/api/v1/assignments/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _assignmentService.Delete(id);

            return Ok(new ResultViewModel
            {
                Message = "Task deletada com sucesso",
                Sucess = true,
                Data = null
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

}