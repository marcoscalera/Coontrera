using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Coontrera.Models;

[Table("tb_agenda")]
public class Agenda
{
    [Key]
    public int Id { get; set; }

    public int IdServico { get; set; }
    [ForeignKey("IdServico")]
    public Servico Servico { get; set; }

    public DateTime DiaSemana { get; set; }

    [Required]
    public string Hora { get; set; }

    public int IdUsuarioGestor { get; set; }
    [ForeignKey("IdUsuarioGestor")]
    public Usuario UsuarioGestor { get; set; }
}
