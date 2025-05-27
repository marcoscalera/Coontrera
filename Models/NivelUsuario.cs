using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_nivel_usuario")]
    public class NivelUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nivel { get; set; }

        [Required]
        public string? Descricao { get; set; }

        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
