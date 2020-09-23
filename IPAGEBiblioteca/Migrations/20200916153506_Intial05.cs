using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Intial05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodBar",
                table: "Livros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pratileira",
                table: "Livros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PratileiraPosicao",
                table: "Livros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Definicoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefinicoesTitulo = table.Column<string>(nullable: false),
                    NIF = table.Column<string>(maxLength: 200, nullable: false),
                    Telemovel = table.Column<string>(maxLength: 400, nullable: true),
                    Rua = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 400, nullable: false),
                    Ramo = table.Column<string>(maxLength: 400, nullable: false),
                    Banco_1 = table.Column<string>(maxLength: 400, nullable: true),
                    Banco_2 = table.Column<string>(maxLength: 400, nullable: true),
                    Banco_3 = table.Column<string>(maxLength: 400, nullable: true),
                    Banco_4 = table.Column<string>(maxLength: 400, nullable: true),
                    Outros = table.Column<string>(maxLength: 400, nullable: true),
                    Photos = table.Column<string>(nullable: true),
                    Photos_Desk1 = table.Column<byte[]>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Regiao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definicoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KeysGens",
                columns: table => new
                {
                    KeysGenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    DataActual = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeysGens", x => x.KeysGenID);
                });

            migrationBuilder.CreateTable(
                name: "SmtpConfigurations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailSender = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Host = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Ssl = table.Column<bool>(nullable: false),
                    Hora1 = table.Column<TimeSpan>(nullable: false),
                    Hora2 = table.Column<TimeSpan>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpConfigurations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Definicoes");

            migrationBuilder.DropTable(
                name: "KeysGens");

            migrationBuilder.DropTable(
                name: "SmtpConfigurations");

            migrationBuilder.DropColumn(
                name: "CodBar",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Pratileira",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "PratileiraPosicao",
                table: "Livros");
        }
    }
}
