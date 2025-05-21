using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Coontrera.Helpers;

[Table("tb_usuario")]
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required, MaxLength(11)]
    public string Telefone { get; set; }

    public DateTime DataCadastro { get; set; }

    [Required]
    public int IdNivel { get; set; }
    [ForeignKey("IdNivel")]
    public NivelUsuario Nivel { get; set; }

    public bool PrimeiraAulaRealizada { get; set; }

    public string SenhaHash { get; set; }  // Armazena o hash da senha no banco

    [NotMapped, Required]
    public string Senha { get; set; }  // Apenas recebe a senha, sem hashing aqui

    public ICollection<Feedback> Feedbacks { get; set; }
    public ICollection<Log> Logs { get; set; }
    public ICollection<AulaTeste> AulasTeste { get; set; }
}
