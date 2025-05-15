using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tb_feedback")]
public class Feedback
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; }

    public bool Aprovado { get; set; }

    [Required]
    public string Mensagem { get; set; }
}
