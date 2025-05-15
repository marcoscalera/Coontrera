using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coontrera.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabelasComPrefixoTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Servicos_IdServico",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_IdUsuarioGestor",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_AulasTeste_Usuarios_IdUsuario",
                table: "AulasTeste");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Usuarios_IdUsuario",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Usuarios_IdUsuario",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Fotos_IdFoto",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_NiveisUsuario_IdNivel",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paginas",
                table: "Paginas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NiveisUsuario",
                table: "NiveisUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AulasTeste",
                table: "AulasTeste");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "Servicos",
                newName: "tb_servico");

            migrationBuilder.RenameTable(
                name: "Paginas",
                newName: "tb_pagina");

            migrationBuilder.RenameTable(
                name: "NiveisUsuario",
                newName: "tb_nivel_usuario");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "tb_log");

            migrationBuilder.RenameTable(
                name: "Fotos",
                newName: "tb_foto");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "tb_feedback");

            migrationBuilder.RenameTable(
                name: "AulasTeste",
                newName: "tb_aula_teste");

            migrationBuilder.RenameTable(
                name: "Agendas",
                newName: "tb_agenda");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_IdNivel",
                table: "tb_usuario",
                newName: "IX_tb_usuario_IdNivel");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_IdFoto",
                table: "tb_servico",
                newName: "IX_tb_servico_IdFoto");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_IdUsuario",
                table: "tb_log",
                newName: "IX_tb_log_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_IdUsuario",
                table: "tb_feedback",
                newName: "IX_tb_feedback_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_AulasTeste_IdUsuario",
                table: "tb_aula_teste",
                newName: "IX_tb_aula_teste_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_IdUsuarioGestor",
                table: "tb_agenda",
                newName: "IX_tb_agenda_IdUsuarioGestor");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_IdServico",
                table: "tb_agenda",
                newName: "IX_tb_agenda_IdServico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_servico",
                table: "tb_servico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_pagina",
                table: "tb_pagina",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_nivel_usuario",
                table: "tb_nivel_usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_log",
                table: "tb_log",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_foto",
                table: "tb_foto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_feedback",
                table: "tb_feedback",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_aula_teste",
                table: "tb_aula_teste",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_agenda",
                table: "tb_agenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_agenda_tb_servico_IdServico",
                table: "tb_agenda",
                column: "IdServico",
                principalTable: "tb_servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_agenda_tb_usuario_IdUsuarioGestor",
                table: "tb_agenda",
                column: "IdUsuarioGestor",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aula_teste_tb_usuario_IdUsuario",
                table: "tb_aula_teste",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_feedback_tb_usuario_IdUsuario",
                table: "tb_feedback",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_log_tb_usuario_IdUsuario",
                table: "tb_log",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_servico_tb_foto_IdFoto",
                table: "tb_servico",
                column: "IdFoto",
                principalTable: "tb_foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_nivel_usuario_IdNivel",
                table: "tb_usuario",
                column: "IdNivel",
                principalTable: "tb_nivel_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_agenda_tb_servico_IdServico",
                table: "tb_agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_agenda_tb_usuario_IdUsuarioGestor",
                table: "tb_agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_aula_teste_tb_usuario_IdUsuario",
                table: "tb_aula_teste");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_feedback_tb_usuario_IdUsuario",
                table: "tb_feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_log_tb_usuario_IdUsuario",
                table: "tb_log");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_servico_tb_foto_IdFoto",
                table: "tb_servico");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_nivel_usuario_IdNivel",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_servico",
                table: "tb_servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_pagina",
                table: "tb_pagina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_nivel_usuario",
                table: "tb_nivel_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_log",
                table: "tb_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_foto",
                table: "tb_foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_feedback",
                table: "tb_feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_aula_teste",
                table: "tb_aula_teste");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_agenda",
                table: "tb_agenda");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "tb_servico",
                newName: "Servicos");

            migrationBuilder.RenameTable(
                name: "tb_pagina",
                newName: "Paginas");

            migrationBuilder.RenameTable(
                name: "tb_nivel_usuario",
                newName: "NiveisUsuario");

            migrationBuilder.RenameTable(
                name: "tb_log",
                newName: "Logs");

            migrationBuilder.RenameTable(
                name: "tb_foto",
                newName: "Fotos");

            migrationBuilder.RenameTable(
                name: "tb_feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "tb_aula_teste",
                newName: "AulasTeste");

            migrationBuilder.RenameTable(
                name: "tb_agenda",
                newName: "Agendas");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_IdNivel",
                table: "Usuarios",
                newName: "IX_Usuarios_IdNivel");

            migrationBuilder.RenameIndex(
                name: "IX_tb_servico_IdFoto",
                table: "Servicos",
                newName: "IX_Servicos_IdFoto");

            migrationBuilder.RenameIndex(
                name: "IX_tb_log_IdUsuario",
                table: "Logs",
                newName: "IX_Logs_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_feedback_IdUsuario",
                table: "Feedbacks",
                newName: "IX_Feedbacks_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_aula_teste_IdUsuario",
                table: "AulasTeste",
                newName: "IX_AulasTeste_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_agenda_IdUsuarioGestor",
                table: "Agendas",
                newName: "IX_Agendas_IdUsuarioGestor");

            migrationBuilder.RenameIndex(
                name: "IX_tb_agenda_IdServico",
                table: "Agendas",
                newName: "IX_Agendas_IdServico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paginas",
                table: "Paginas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NiveisUsuario",
                table: "NiveisUsuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AulasTeste",
                table: "AulasTeste",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Servicos_IdServico",
                table: "Agendas",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_IdUsuarioGestor",
                table: "Agendas",
                column: "IdUsuarioGestor",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AulasTeste_Usuarios_IdUsuario",
                table: "AulasTeste",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Usuarios_IdUsuario",
                table: "Feedbacks",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Usuarios_IdUsuario",
                table: "Logs",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Fotos_IdFoto",
                table: "Servicos",
                column: "IdFoto",
                principalTable: "Fotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_NiveisUsuario_IdNivel",
                table: "Usuarios",
                column: "IdNivel",
                principalTable: "NiveisUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
