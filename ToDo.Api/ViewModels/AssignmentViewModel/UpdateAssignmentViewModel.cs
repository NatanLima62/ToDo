using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.ViewModels.AssignmentViewModel;

public class UpdateAssignmentViewModel
{
    [Required(ErrorMessage = "O Id da task não pode ser vazio")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "A descrição da task não pode ser vazio")]
    [MinLength(3, ErrorMessage = "A descrição da task deve ter no minimo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "A descrição da task deve ter no maximo 280 caracteres")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "O Id da task não pode ser vazio")]
    public int UserId { get; set; }
    
    public int? TodoId { get; set; }

    public bool Conclued { get; set; } = false;
    
    public DateTime? DeadLine { get; set; }
}