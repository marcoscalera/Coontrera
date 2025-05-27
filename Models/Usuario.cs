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
        public string? Nome { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required, MaxLength(11)]
        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required]
        public int IdNivel { get; set; }

        [ForeignKey("IdNivel")]
        public virtual NivelUsuario? Nivel { get; set; }

        public bool PrimeiraAulaRealizada { get; set; }

        public string? SenhaHash { get; set; }

        [NotMapped, Required]
        public string? Senha { get; set; }

        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Log>? Logs { get; set; }
        public virtual ICollection<AulaTeste>? AulasTeste { get; set; }
    }
}
