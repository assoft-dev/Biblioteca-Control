using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Initial04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros");

            migrationBuilder.AddColumn<bool>(
                name: "AutoresConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bibliotecas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditoraConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LivrosConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaisConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Usuarios",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "autoModelsID",
                table: "Livros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EditoraModelsID",
                table: "Livros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValide",
                table: "Livros",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Editora",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editora_Pais_PaisID",
                table: "Editora");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editora_EditoraModelsID",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_autoModelsID",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "AutoresConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "Bibliotecas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "EditoraConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "LivrosConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "PaisConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "Usuarios",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "IsValide",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "autoModelsID",
                table: "Livros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EditoraModelsID",
                table: "Livros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Editora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}
