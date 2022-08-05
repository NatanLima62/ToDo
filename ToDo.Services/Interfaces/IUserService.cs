using ToDo.Services.DTOs;

namespace ToDo.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO userDto);
    Task<List<UserDTO>> GetAll();
    Task<UserDTO> GetBYId(int id);
    Task<UserDTO> GetByEmail(string email);
    Task<UserDTO> Update(UserDTO userDto);
    Task Delete(int id);
    Task<AuthenticatedUserDTO> Autentificar(LoginUserDTO loginUserDto);
}