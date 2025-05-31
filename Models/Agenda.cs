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
    public Servico? Servico { get; set; }

    // se for um dia da semana mesmo, o ideal seria trocar para enum
    public DateTime DiaSemana { get; set; }

    [Required]
    public string Hora { get; set; } = string.Empty;

    public int IdUsuarioGestor { get; set; }

    [ForeignKey("IdUsuarioGestor")]
    public Usuario? UsuarioGestor { get; set; }
}
