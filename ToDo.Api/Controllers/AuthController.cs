using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Utilities;
using ToDo.Api.ViewModels.LoginViewModel;
using ToDo.Api.ViewModels.ResultViewModel;
using ToDo.Core.Exeption;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Api.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;


    public AuthController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    [HttpPost]
    [Route("/api/v1/auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
    {
        try
        {
            var user = _mapper.Map<LoginUserDTO>(loginViewModel);
            
            var token = await _userService.Autentificar(user);
    
            return Ok(new ResultViewModel
            {
                Message = "Token gerado com sucesso",
                Sucess = true,
                Data = token
            });
        }
        catch (DomainExeption exeptions)
        {
            return BadRequest(Responses.DomainErrorMessage(exeptions.Message));
        }
        catch (Exception e)
        {
            return StatusCode(401,Responses.ApplicationErrorMessage());
        }
    }
}