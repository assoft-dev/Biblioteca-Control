using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAGEBiblioteca.Migrations
{
    public partial class Initial07 : Migration
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
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseModelsID",
                table: "Turma",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AlunoConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClasseConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estudantes",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InstituicaoConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TurmaConsultas",
                table: "Permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TurmaID",
                table: "Aluno",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoID",
                table: "Aluno",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValido",
                table: "Aluno",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NumeroEstudante",
                table: "Aluno",
                nullable: true);

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
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma",
                column: "ClasseModelsID",
                principalTable: "Classe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "AlunoConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "ClasseConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "Estudantes",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "InstituicaoConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "TurmaConsultas",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "IsValido",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "NumeroEstudante",
                table: "Aluno");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseModelsID",
                table: "Turma",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TurmaID",
                table: "Aluno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoID",
                table: "Aluno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
                name: "FK_Turma_Classe_ClasseModelsID",
                table: "Turma",
                column: "ClasseModelsID",
                principalTable: "Classe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
