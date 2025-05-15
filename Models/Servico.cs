using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tb_servico")]
public class Servico
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Conteudo { get; set; }

    public int IdFoto { get; set; }
    [ForeignKey("IdFoto")]
    public Foto Foto { get; set; }

    public ICollection<Agenda> Agendas { get; set; }
}
