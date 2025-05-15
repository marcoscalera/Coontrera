using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tb_nivel_usuario")]
public class NivelUsuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nivel { get; set; }

    [Required]
    public string Descricao { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
}
