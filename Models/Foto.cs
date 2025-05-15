using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tb_foto")]
public class Foto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Caminho { get; set; }

    public ICollection<Servico> Servicos { get; set; }
}
