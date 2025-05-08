using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_feedbacks")]
    public class Feedbacks
    {
        [Key] 
        [Required]
        public int Id { get; set; }

        [Required] 
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [MaxLength(50)]
        public string Comentario { get; set; }

        [Required]
        public DateTime DataEnvio { get; set; }

        [Required]
        public Boolean Aprovado { get; set; }

        [Required]
        public string VerificadoPor {  get; set; }
    }
}
