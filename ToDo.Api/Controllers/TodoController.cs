using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Utilities;
using ToDo.Api.ViewModels.ResultViewModel;
using ToDo.Api.ViewModels.TodoViewModel;
using ToDo.Core.Exeption;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Api.Controllers;

[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IMapper _mapper;

    public TodoController(ITodoService todoService, IMapper mapper)
    {
        _todoService = todoService;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [Route("/api/v1/todos/create")]
    public async Task<IActionResult> Create([FromBody] CreateTodoViewModel createTodoViewModel)
    {
        try
        {
            var todo = _mapper.Map<TodoDTO>(createTodoViewModel);

            var todoCreated = await _todoService.Create(todo);

            return Ok(new ResultViewModel
            {
                Message = "Todo criado com sucesso",
                Sucess = true,
                Data = todoCreated
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
    [Route("/api/v1/todos/get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allTodos = await _todoService.GetAll();

            return Ok(new ResultViewModel
            {
                Message = "Todos encontrados com sucesso!",
                Sucess = true,
                Data = allTodos
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
    [Route("api/v1/todos/get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _todoService.GetById(id);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum Todo encontrado com o id informado",
                    Sucess = false,
                    Data = null
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Todo encontrado com sucesso",
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
    [Route("api/v1/todos/update")]
    public async Task<IActionResult> Update([FromBody] UpdateTodoViewModel updateTodoViewModel)
    {
        try
        {
            var todo = _mapper.Map<TodoDTO>(updateTodoViewModel);

            var todoUpdated = await _todoService.Update(todo);

            return Ok(new ResultViewModel
            {
                Message = "Todo alterado com sucesso!",
                Sucess = true,
                Data = todoUpdated
            });
        }
        catch (DomainExeption exception)
        {
            return BadRequest(Responses.DomainErrorMessage(exception.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpDelete]
    [Authorize]
    [Route("/api/v1/todos/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _todoService.Delete(id);

            return Ok(new ResultViewModel
            {
                Message = "Todo excluido com sucesso",
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