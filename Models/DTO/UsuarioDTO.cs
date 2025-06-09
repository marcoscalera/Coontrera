using System.ComponentModel.DataAnnotations;

namespace Coontrera.Models.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(24, ErrorMessage = "O nome deve ter no máximo 24 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\sÀ-ÖØ-öø-ÿ'-]+$", ErrorMessage = "O nome deve conter apenas letras, espaços, apóstrofos ou hífens.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [MaxLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}