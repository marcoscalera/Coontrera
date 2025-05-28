using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Coontrera.Models;

[Table("tb_aula_teste")]
public class AulaTeste
{
    [Key]
    public int Id { get; set; } 

    public int IdUsuario { get; set; } 
    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; } 

    public bool Agendada { get; set; } 
    public bool Realizada { get; set; } 

    public DateTime? DataHora { get; set; } 
}
