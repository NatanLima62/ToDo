namespace ToDo.Services.DTOs;

public class AuthenticatedUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}