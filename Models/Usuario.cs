using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coontrera.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataCadastro { get; set; }


        [Required]
        public int IdNivel { get; set; }

        [ForeignKey("IdNivel")]
        public virtual NivelUsuario Nivel { get; set; }

        public bool PrimeiraAulaRealizada { get; set; }

        public string SenhaHash { get; set; } = string.Empty;

        [NotMapped]
        public string Senha { get; set; } = string.Empty;

        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
        public virtual ICollection<AulaTeste> AulasTeste { get; set; } = new List<AulaTeste>();
    }
}
