using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ToDo.Core.Exeption;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;
using ToDo.Services.Configuration;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserServices(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);

        if (userExists != null)
        {
            throw new DomainExeption("Já existe um usuário com o email cadastrado");
        }

        var user = _mapper.Map<User>(userDto);
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        user.Validate();

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(userDto);
    }

    public async Task<List<UserDTO>> GetAll()
    {
        var allUsers = await _userRepository.GetAll();
        
        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetBYId(int id)
    {
        var user = await _userRepository.GetById(id);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.GetById(userDto.Id);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com o id informado (aki)");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate();
        
        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDTO>(userDto);
    }

    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }

    public async Task<AuthenticatedUserDTO> Autentificar(LoginUserDTO loginUserDto)
    {
        var usuario = await _userRepository.GetByEmail(loginUserDto.Login);

        if (usuario == null)
        {
            throw new DomainExeption("Combinação de usuário e senha incorreta!");
        }
        
        //fazer check da senha
        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, loginUserDto.Password);
        
        if (result == PasswordVerificationResult.Failed)
        {
            throw new DomainExeption("Combinação de usuário e senha incorreta!");
        }
        
        //gerar jwt
        return new AuthenticatedUserDTO
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Name = usuario.Name,
            Token = GenerateToken(usuario)
        };
    }
    private static string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}