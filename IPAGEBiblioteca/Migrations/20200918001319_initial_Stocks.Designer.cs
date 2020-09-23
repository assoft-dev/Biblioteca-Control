﻿// <auto-generated />
using System;
using IPAGEBiblioteca.Repository.Helps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IPAGEBiblioteca.Migrations
{
    [DbContext(typeof(BiblioteContext))]
    [Migration("20200918001319_initial_Stocks")]
    partial class initial_Stocks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IPAGEBiblioteca.Models.AlunoModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstituicaoID")
                        .HasColumnType("int");

                    b.Property<bool>("IsValido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroEstudante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int>("TurmaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InstituicaoID");

                    b.HasIndex("TurmaID");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.AutorModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.ClasseModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("IdadeFinaliza")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IdadeInicia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.DefinicoesModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Banco_1")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Banco_2")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Banco_3")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Banco_4")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("DefinicoesTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Outros")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photos_Desk1")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Ramo")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Regiao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telemovel")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Definicoes");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.EditoraModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaisID")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PaisID");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.GruposModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PermissoesModelsID")
                        .HasColumnType("int");

                    b.Property<string>("Referencias")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PermissoesModelsID");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.InstituicaoModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.KeysGensModels", b =>
                {
                    b.Property<int>("KeysGenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataActual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KeysGenID");

                    b.ToTable("KeysGens");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.LivrosModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("CodBar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditoraModelsID")
                        .HasColumnType("int");

                    b.Property<bool>("IsValide")
                        .HasColumnType("bit");

                    b.Property<string>("Pratileira")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PratileiraPosicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("autoModelsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EditoraModelsID");

                    b.HasIndex("autoModelsID");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.LogsModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userModelsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("userModelsID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PaisModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PedidosModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoModelsID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocNumero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AlunoModelsID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PedidosOrdemModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LivrosModelsID")
                        .HasColumnType("int");

                    b.Property<int?>("PedidosModelsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LivrosModelsID");

                    b.HasIndex("PedidosModelsID");

                    b.ToTable("PedidosOrdem");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PermissoesModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AlunoConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("AutoresConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("Bibliotecas")
                        .HasColumnType("bit");

                    b.Property<bool>("ClasseConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("EditoraConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("Estudantes")
                        .HasColumnType("bit");

                    b.Property<bool>("InstituicaoConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("Leituras")
                        .HasColumnType("bit");

                    b.Property<bool>("LeiturasSolicitacoes")
                        .HasColumnType("bit");

                    b.Property<bool>("LivrosConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("PaisConsultas")
                        .HasColumnType("bit");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Stocks")
                        .HasColumnType("bit");

                    b.Property<bool>("StocksRegistar")
                        .HasColumnType("bit");

                    b.Property<bool>("TurmaConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("Usuarios")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuariosConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuariosGrupos")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuariosPermissoes")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuariosRegistar")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.SmtpConfigurationsModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Hora1")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Hora2")
                        .HasColumnType("time");

                    b.Property<string>("Host")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailSender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("Ssl")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("SmtpConfigurations");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.StocksModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Isvalid")
                        .HasColumnType("bit");

                    b.Property<int>("LivrosModelsID")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Qtd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantidadeMaxima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantidadeMinima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("LivrosModelsID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.TurmaModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasseModelsID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClasseModelsID");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.UserModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GruposModelsID")
                        .HasColumnType("int");

                    b.Property<bool>("IsValido")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GruposModelsID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.AlunoModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.InstituicaoModels", "Instituicao")
                        .WithMany("AlunoModels")
                        .HasForeignKey("InstituicaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPAGEBiblioteca.Models.TurmaModels", "Turma")
                        .WithMany("AlunoModels")
                        .HasForeignKey("TurmaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.EditoraModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.PaisModels", "Pais")
                        .WithMany("EditoraModels")
                        .HasForeignKey("PaisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.GruposModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.PermissoesModels", "PermissoesModels")
                        .WithMany("GruposModels")
                        .HasForeignKey("PermissoesModelsID");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.LivrosModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.EditoraModels", "EditoraModels")
                        .WithMany("LivrosModels")
                        .HasForeignKey("EditoraModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPAGEBiblioteca.Models.AutorModels", "autoModels")
                        .WithMany("LivrosModels")
                        .HasForeignKey("autoModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.LogsModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.UserModels", "userModels")
                        .WithMany("Logs")
                        .HasForeignKey("userModelsID");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PedidosModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.AlunoModels", "AlunoModels")
                        .WithMany("PedidosModels")
                        .HasForeignKey("AlunoModelsID");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.PedidosOrdemModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.LivrosModels", "LivrosModels")
                        .WithMany("PedidosOrdemModels")
                        .HasForeignKey("LivrosModelsID");

                    b.HasOne("IPAGEBiblioteca.Models.PedidosModels", "PedidosModels")
                        .WithMany("PedidosOrdemModels")
                        .HasForeignKey("PedidosModelsID");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.StocksModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.LivrosModels", "LivrosModels")
                        .WithMany("StocksModels")
                        .HasForeignKey("LivrosModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.TurmaModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.ClasseModels", "ClasseModels")
                        .WithMany("TurmaModels")
                        .HasForeignKey("ClasseModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.UserModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.GruposModels", "GruposModels")
                        .WithMany("UserModels")
                        .HasForeignKey("GruposModelsID");
                });
#pragma warning restore 612, 618
        }
    }
}
