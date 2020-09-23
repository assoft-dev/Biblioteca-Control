using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    IdadeInicia = table.Column<decimal>(nullable: false),
                    IdadeFinaliza = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuariosConsultas = table.Column<bool>(nullable: false),
                    UsuariosRegistar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    ClasseModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Turma_Classe_ClasseModelsID",
                        column: x => x.ClasseModelsID,
                        principalTable: "Classe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    PaisID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Editora_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencias = table.Column<string>(nullable: true),
                    PermissoesModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grupos_Permissoes_PermissoesModelsID",
                        column: x => x.PermissoesModelsID,
                        principalTable: "Permissoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataRegisto = table.Column<DateTime>(nullable: false),
                    TurmaID = table.Column<int>(nullable: true),
                    InstituicaoID = table.Column<int>(nullable: true),
                    Sexo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aluno_Instituicao_InstituicaoID",
                        column: x => x.InstituicaoID,
                        principalTable: "Instituicao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_TurmaID",
                        column: x => x.TurmaID,
                        principalTable: "Turma",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    SBN = table.Column<string>(nullable: true),
                    Edicao = table.Column<string>(nullable: true),
                    AnoLancamento = table.Column<int>(nullable: false),
                    EditoraModelsID = table.Column<int>(nullable: true),
                    autoModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Livros_Editora_EditoraModelsID",
                        column: x => x.EditoraModelsID,
                        principalTable: "Editora",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livros_Autor_autoModelsID",
                        column: x => x.autoModelsID,
                        principalTable: "Autor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsValido = table.Column<bool>(nullable: false),
                    GruposModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Grupos_GruposModelsID",
                        column: x => x.GruposModelsID,
                        principalTable: "Grupos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumero = table.Column<string>(nullable: true),
                    DataReserva = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    AlunoModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Aluno_AlunoModelsID",
                        column: x => x.AlunoModelsID,
                        principalTable: "Aluno",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    userModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Logs_User_userModelsID",
                        column: x => x.userModelsID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidosOrdem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumero = table.Column<string>(nullable: true),
                    DataInsert = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    LivrosModelsID = table.Column<int>(nullable: true),
                    PedidosModelsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosOrdem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PedidosOrdem_Livros_LivrosModelsID",
                        column: x => x.LivrosModelsID,
                        principalTable: "Livros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidosOrdem_Pedidos_PedidosModelsID",
                        column: x => x.PedidosModelsID,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_InstituicaoID",
                table: "Aluno",
                column: "InstituicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaID",
                table: "Aluno",
                column: "TurmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Editora_PaisID",
                table: "Editora",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_PermissoesModelsID",
                table: "Grupos",
                column: "PermissoesModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraModelsID",
                table: "Livros",
                column: "EditoraModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_autoModelsID",
                table: "Livros",
                column: "autoModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_userModelsID",
                table: "Logs",
                column: "userModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AlunoModelsID",
                table: "Pedidos",
                column: "AlunoModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosOrdem_LivrosModelsID",
                table: "PedidosOrdem",
                column: "LivrosModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosOrdem_PedidosModelsID",
                table: "PedidosOrdem",
                column: "PedidosModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ClasseModelsID",
                table: "Turma",
                column: "ClasseModelsID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GruposModelsID",
                table: "User",
                column: "GruposModelsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PedidosOrdem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Editora");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Classe");
        }
    }
}
