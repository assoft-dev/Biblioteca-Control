using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Initial03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UsuariosGrupos",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsuariosPermissoes",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuariosGrupos",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "UsuariosPermissoes",
                table: "Permissoes");
        }
    }
}
