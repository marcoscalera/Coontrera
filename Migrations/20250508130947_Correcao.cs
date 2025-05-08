using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coontrera.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "tb_feedbacks");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "tb_contatos");

            migrationBuilder.RenameTable(
                name: "Aulas",
                newName: "tb_aulas");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "tb_usuario",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tb_usuario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "tb_usuario",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "primeira_aula_realizada",
                table: "tb_usuario",
                newName: "PrimeiraAulaRealizada");

            migrationBuilder.RenameColumn(
                name: "nivel_usuario",
                table: "tb_usuario",
                newName: "NivelUsuario");

            migrationBuilder.RenameColumn(
                name: "data_cadastro",
                table: "tb_usuario",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "tb_usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "comentario",
                table: "tb_feedbacks",
                newName: "Comentario");

            migrationBuilder.RenameColumn(
                name: "aprovado",
                table: "tb_feedbacks",
                newName: "Aprovado");

            migrationBuilder.RenameColumn(
                name: "verificado_por",
                table: "tb_feedbacks",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "data_envio",
                table: "tb_feedbacks",
                newName: "DataEnvio");

            migrationBuilder.RenameColumn(
                name: "id_feedback",
                table: "tb_feedbacks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "mensagem",
                table: "tb_contatos",
                newName: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "tb_contatos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "data_contato",
                table: "tb_contatos",
                newName: "DataContato");

            migrationBuilder.RenameColumn(
                name: "id_contato",
                table: "tb_contatos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "tb_aulas",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "data_aula",
                table: "tb_aulas",
                newName: "DataAula");

            migrationBuilder.RenameColumn(
                name: "id_aula",
                table: "tb_aulas",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "tb_usuario",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tb_usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "tb_usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "tb_feedbacks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "VerificadoPor",
                table: "tb_feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Mensagem",
                table: "tb_contatos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tb_aulas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_feedbacks",
                table: "tb_feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_contatos",
                table: "tb_contatos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_aulas",
                table: "tb_aulas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feedbacks_IdUsuario",
                table: "tb_feedbacks",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_contatos_IdUsuario",
                table: "tb_contatos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aulas_IdUsuario",
                table: "tb_aulas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aulas_tb_usuario_IdUsuario",
                table: "tb_aulas",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_contatos_tb_usuario_IdUsuario",
                table: "tb_contatos",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_feedbacks_tb_usuario_IdUsuario",
                table: "tb_feedbacks",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_aulas_tb_usuario_IdUsuario",
                table: "tb_aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_contatos_tb_usuario_IdUsuario",
                table: "tb_contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_feedbacks_tb_usuario_IdUsuario",
                table: "tb_feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_feedbacks",
                table: "tb_feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_tb_feedbacks_IdUsuario",
                table: "tb_feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_contatos",
                table: "tb_contatos");

            migrationBuilder.DropIndex(
                name: "IX_tb_contatos_IdUsuario",
                table: "tb_contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_aulas",
                table: "tb_aulas");

            migrationBuilder.DropIndex(
                name: "IX_tb_aulas_IdUsuario",
                table: "tb_aulas");

            migrationBuilder.DropColumn(
                name: "VerificadoPor",
                table: "tb_feedbacks");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "tb_feedbacks",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "tb_contatos",
                newName: "Contatos");

            migrationBuilder.RenameTable(
                name: "tb_aulas",
                newName: "Aulas");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Usuarios",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Usuarios",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "PrimeiraAulaRealizada",
                table: "Usuarios",
                newName: "primeira_aula_realizada");

            migrationBuilder.RenameColumn(
                name: "NivelUsuario",
                table: "Usuarios",
                newName: "nivel_usuario");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Usuarios",
                newName: "data_cadastro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "Comentario",
                table: "Feedbacks",
                newName: "comentario");

            migrationBuilder.RenameColumn(
                name: "Aprovado",
                table: "Feedbacks",
                newName: "aprovado");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Feedbacks",
                newName: "verificado_por");

            migrationBuilder.RenameColumn(
                name: "DataEnvio",
                table: "Feedbacks",
                newName: "data_envio");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Feedbacks",
                newName: "id_feedback");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "Contatos",
                newName: "mensagem");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Contatos",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "DataContato",
                table: "Contatos",
                newName: "data_contato");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contatos",
                newName: "id_contato");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Aulas",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "DataAula",
                table: "Aulas",
                newName: "data_aula");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Aulas",
                newName: "id_aula");

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "comentario",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "mensagem",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Aulas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "id_feedback");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "id_contato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas",
                column: "id_aula");
        }
    }
}
