using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.ViewModels.LoginViewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "O login não pode ser vazio")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "A senha não pode ser vazio")]
    public string Password { get; set; }
}