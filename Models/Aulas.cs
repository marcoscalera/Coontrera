using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_aulas")]
    public class Aulas
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime DataAula { get; set; }

        [Required]
        [MaxLength(30)]
        public string status {  get; set; }
    }
}
