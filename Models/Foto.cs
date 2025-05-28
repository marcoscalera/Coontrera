using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

[Table("tb_foto")]
public class Foto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Caminho { get; set; } = string.Empty;

    public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
