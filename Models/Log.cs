﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tb_log")]
public class Log
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; }

    [Required]
    public string Acao { get; set; }

    public DateTime DataHora { get; set; }
}
