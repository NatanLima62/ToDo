using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.ViewModels.TodoViewModel;

public class CreateTodoViewModel
{
    [Required(ErrorMessage = "O nome do Todo não pode ser vazio")]
    [MinLength(3, ErrorMessage = "O nome do Todo deve ter no minimo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "O nome do Todo deve ter no maximo 180 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O UserId do Todo não pode ser vazio")]
    public int UserId { get; set; }
}