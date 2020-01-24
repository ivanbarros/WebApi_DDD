using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage="Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
