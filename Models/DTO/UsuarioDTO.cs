using System.ComponentModel.DataAnnotations;

namespace Coontrera.Models.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório."), MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório."), EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; } = string.Empty;
    }
}
