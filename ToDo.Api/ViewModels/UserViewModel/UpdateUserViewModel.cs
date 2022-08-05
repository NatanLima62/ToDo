using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.ViewModels.UserViewModel;

public class UpdateUserViewModel
{
    [Required(ErrorMessage = "O id do usuáio não pode ser vazio")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do usuáio não pode ser vazio")]
    [MinLength(3, ErrorMessage = "O nome do usuário deve ter no minimo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "O nome do usuário deve ter no maximo 180 caracteres")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O email do usuáio não pode ser vazio")]
    [MinLength(11, ErrorMessage = "O email do usuário deve ter no minimo 11 caracteres")]
    [MaxLength(180, ErrorMessage = "O email do usuário deve ter no maximo 180 caracteres")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email do usuário deve ser válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O password do usuáio não pode ser vazio")]
    [MinLength(8, ErrorMessage = "O password do usuário deve ter no minimo 8 caracteres")]
    [MaxLength(80, ErrorMessage = "O password do usuário deve ter no maximo 80 caracteres")]
    public string Password { get; set; }
}