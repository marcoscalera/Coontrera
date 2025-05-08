using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_contatos")]
    public class Contatos
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime DataContato { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mensagem { get; set; }
    }
}
