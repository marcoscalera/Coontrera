using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [Required]
        public int Id {  get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public bool NivelUsuario { get; set; }

        [Required]
        public bool PrimeiraAulaRealizada { get; set; }
    }
}
