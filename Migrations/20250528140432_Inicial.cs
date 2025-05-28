using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coontrera.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_foto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_nivel_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nivel_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pagina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pagina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFoto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_servico_tb_foto_IdFoto",
                        column: x => x.IdFoto,
                        principalTable: "tb_foto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNivel = table.Column<int>(type: "int", nullable: false),
                    PrimeiraAulaRealizada = table.Column<bool>(type: "bit", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_usuario_tb_nivel_usuario_IdNivel",
                        column: x => x.IdNivel,
                        principalTable: "tb_nivel_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioGestor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_agenda_tb_servico_IdServico",
                        column: x => x.IdServico,
                        principalTable: "tb_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_agenda_tb_usuario_IdUsuarioGestor",
                        column: x => x.IdUsuarioGestor,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_aula_teste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Agendada = table.Column<bool>(type: "bit", nullable: false),
                    Realizada = table.Column<bool>(type: "bit", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aula_teste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_aula_teste_tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Aprovado = table.Column<bool>(type: "bit", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_feedback_tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Acao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_log_tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_agenda_IdServico",
                table: "tb_agenda",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_tb_agenda_IdUsuarioGestor",
                table: "tb_agenda",
                column: "IdUsuarioGestor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aula_teste_IdUsuario",
                table: "tb_aula_teste",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feedback_IdUsuario",
                table: "tb_feedback",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_log_IdUsuario",
                table: "tb_log",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_servico_IdFoto",
                table: "tb_servico",
                column: "IdFoto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_IdNivel",
                table: "tb_usuario",
                column: "IdNivel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_agenda");

            migrationBuilder.DropTable(
                name: "tb_aula_teste");

            migrationBuilder.DropTable(
                name: "tb_feedback");

            migrationBuilder.DropTable(
                name: "tb_log");

            migrationBuilder.DropTable(
                name: "tb_pagina");

            migrationBuilder.DropTable(
                name: "tb_servico");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_foto");

            migrationBuilder.DropTable(
                name: "tb_nivel_usuario");
        }
    }
}
