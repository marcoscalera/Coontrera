using System.ComponentModel.DataAnnotations;

namespace Coontrera.Models.DTOs
{
    public class UsuarioUpdateDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório."), MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nível é obrigatório.")]
        public int IdNivel { get; set; }

        public bool PrimeiraAulaRealizada { get; set; }
    }
}
