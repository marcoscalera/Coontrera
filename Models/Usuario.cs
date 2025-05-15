using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Coontrera.Helpers; // se colocou a classe PasswordHasher lá

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

    public string SenhaHash { get; set; }  // vai para o banco

    [NotMapped, Required]
    public string Senha   // usado só para entrada
    {
        set
        {
            var hasher = new PasswordHasher();
            SenhaHash = hasher.HashPassword(value);
        }
    }

    public bool VerificarSenha(string senhaDigitada)
    {
        var hasher = new PasswordHasher();
        return hasher.VerifyPassword(SenhaHash, senhaDigitada);
    }

    public ICollection<Feedback> Feedbacks { get; set; }
    public ICollection<Log> Logs { get; set; }
    public ICollection<AulaTeste> AulasTeste { get; set; }
}
