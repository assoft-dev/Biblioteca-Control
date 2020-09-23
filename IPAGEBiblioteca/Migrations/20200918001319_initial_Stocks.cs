using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class initial_Stocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Leituras",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LeiturasSolicitacoes",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Stocks",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StocksRegistar",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qtd = table.Column<decimal>(nullable: false),
                    QuantidadeMinima = table.Column<decimal>(nullable: false),
                    QuantidadeMaxima = table.Column<decimal>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Isvalid = table.Column<bool>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    LivrosModelsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stocks_Livros_LivrosModelsID",
                        column: x => x.LivrosModelsID,
                        principalTable: "Livros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LivrosModelsID",
                table: "Stocks",
                column: "LivrosModelsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropColumn(
                name: "Leituras",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "LeiturasSolicitacoes",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "Stocks",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "StocksRegistar",
                table: "Permissoes");
        }
    }
}
