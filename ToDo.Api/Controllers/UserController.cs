using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Utilities;
using ToDo.Api.ViewModels.ResultViewModel;
using ToDo.Api.ViewModels.UserViewModel;
using ToDo.Core.Exeption;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
    {
        try
        {
            var user = _mapper.Map<UserDTO>(userViewModel);

            var userCreated = await _userService.Create(user);

            return Ok(new ResultViewModel
            {
                Message = "Usuário criado com sucesso!",
                Sucess = true,
                Data = userCreated
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message, exeptions.Errors));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    //Testar as saidas do usuario criado
    
    // [HttpGet]
    // [Authorize]
    // [Route("/api/v1/get-all/users")]
    // public async Task<IActionResult> GetAll()
    // {
    //     try
    //     {
    //         var allUsers = await _userService.GetAll();
    //
    //         return Ok(new ResultViewModel
    //         {
    //             Message = "Usuários encontrados com sucesso!",
    //             Sucess = true,
    //             Data = allUsers
    //         });
    //     }
    //     catch (DomainExeption exeptions)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());
    //     }
    // }
    //
    // [HttpGet]
    // [Authorize]
    // [Route("/api/v1/get-by-id/users/{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     try
    //     {
    //         var user = await _userService.GetBYId(id);
    //
    //         if (user == null)
    //         {
    //             return Ok(new ResultViewModel
    //             {
    //                 Message = "Nenhum usuário encontrado com o id informado",
    //                 Sucess = false,
    //                 Data = null
    //             });
    //         }
    //         return Ok(new ResultViewModel
    //         {
    //             Message = "Usuário encontrado com sucesso!",
    //             Sucess = true,
    //             Data = user
    //         });
    //     }
    //     catch (DomainExeption exception)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(exception.Message));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());
    //     }
    // }
    //
    // [HttpGet]
    // [Authorize]
    // [Route("/api/v1/users/get-by-email/{email}")]
    // public async Task<IActionResult> GetById(string email)
    // {
    //     try
    //     {
    //         var user = await _userService.GetByEmail(email);
    //
    //         if (user == null)
    //         {
    //             return Ok(new ResultViewModel
    //             {
    //                 Message = "Nenhum usuário foi encontrado com o email informado",
    //                 Sucess = false,
    //                 Data = null
    //             });
    //         }
    //
    //         return Ok(new ResultViewModel
    //         {
    //             Message = "Usuário encontrado com sucesso",
    //             Sucess = true,
    //             Data = user
    //         });
    //     }
    //     catch (DomainExeption exeptions)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());
    //     }
    // }
    //
    // [HttpPut]
    // [Authorize]
    // [Route("/api/v1/update/users/")]
    // public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
    // {
    //     try
    //     {
    //         var user = _mapper.Map<UserDTO>(updateUserViewModel);
    //
    //         var userUpdated = await _userService.Update(user);
    //
    //         return Ok(new ResultViewModel
    //         {
    //             Message = "Usuário atualizado com sucesso",
    //             Sucess = true,
    //             Data = userUpdated
    //         });
    //     }
    //     catch (DomainExeption exeptions)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());
    //     }
    // }
    //
    // [HttpDelete]
    // [Authorize]
    // [Route("/api/v1/users/delete/{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     try
    //     {
    //         await _userService.Delete(id);
    //
    //         return Ok(new ResultViewModel
    //         {
    //             Message = "Usuário excluido com sucesso",
    //             Sucess = true,
    //             Data = null
    //         });
    //     }
    //     catch (DomainExeption exeptions)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());
    //     }
    // }
}