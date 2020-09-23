using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Initial_Pedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Instituicao_InstituicaoID",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_User_userModelsID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosOrdem_Pedidos_PedidosModelsID",
                table: "PedidosOrdem");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Livros_LivrosModelsID",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_PedidosOrdem_PedidosModelsID",
                table: "PedidosOrdem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataInsert",
                table: "PedidosOrdem");

            migrationBuilder.DropColumn(
                name: "PedidosModelsID",
                table: "PedidosOrdem");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuantidadeMinima",
                table: "Stocks",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuantidadeMaxima",
                table: "Stocks",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qtd",
                table: "Stocks",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "Stocks",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "LivrosModelsID",
                table: "PedidosOrdem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocNumero",
                table: "PedidosOrdem",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "PedidosOrdem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "PedidosOrdem",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "DocNumero",
                table: "Pedidos",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoModelsID",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Pedidos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PedidosEstado",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Totalgeral",
                table: "Pedidos",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "IdadeInicia",
                table: "Classe",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IdadeFinaliza",
                table: "Classe",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "DocNumero");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosOrdem_DocNumero",
                table: "PedidosOrdem",
                column: "DocNumero");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Instituicao_InstituicaoID",
                table: "Aluno",
                column: "InstituicaoID",
                principalTable: "Instituicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno",
                column: "TurmaID",
                principalTable: "Turma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros",
                column: "EditoraModelsID",
                principalTable: "Editora",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros",
                column: "autoModelsID",
                principalTable: "Autor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_User_userModelsID",
                table: "Logs",
                column: "userModelsID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosOrdem_Pedidos_DocNumero",
                table: "PedidosOrdem",
                column: "DocNumero",
                principalTable: "Pedidos",
                principalColumn: "DocNumero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Livros_LivrosModelsID",
                table: "Stocks",
                column: "LivrosModelsID",
                principalTable: "Livros",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma",
                column: "ClasseModelsID",
                principalTable: "Classe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Instituicao_InstituicaoID",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_User_userModelsID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosOrdem_Pedidos_DocNumero",
                table: "PedidosOrdem");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Livros_LivrosModelsID",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_PedidosOrdem_DocNumero",
                table: "PedidosOrdem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "PedidosOrdem");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "PedidosOrdem");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidosEstado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Totalgeral",
                table: "Pedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuantidadeMinima",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuantidadeMaxima",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qtd",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<int>(
                name: "LivrosModelsID",
                table: "PedidosOrdem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DocNumero",
                table: "PedidosOrdem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInsert",
                table: "PedidosOrdem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PedidosModelsID",
                table: "PedidosOrdem",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoModelsID",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DocNumero",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<decimal>(
                name: "IdadeInicia",
                table: "Classe",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IdadeFinaliza",
                table: "Classe",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosOrdem_PedidosModelsID",
                table: "PedidosOrdem",
                column: "PedidosModelsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Instituicao_InstituicaoID",
                table: "Aluno",
                column: "InstituicaoID",
                principalTable: "Instituicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno",
                column: "TurmaID",
                principalTable: "Turma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora",
                column: "PaisID",
                principalTable: "Pais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros",
                column: "EditoraModelsID",
                principalTable: "Editora",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros",
                column: "autoModelsID",
                principalTable: "Autor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_User_userModelsID",
                table: "Logs",
                column: "userModelsID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosOrdem_Pedidos_PedidosModelsID",
                table: "PedidosOrdem",
                column: "PedidosModelsID",
                principalTable: "Pedidos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Livros_LivrosModelsID",
                table: "Stocks",
                column: "LivrosModelsID",
                principalTable: "Livros",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma",
                column: "ClasseModelsID",
                principalTable: "Classe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
