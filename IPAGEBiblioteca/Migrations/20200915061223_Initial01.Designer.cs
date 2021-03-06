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
    [Migration("20200915061223_Initial01")]
    partial class Initial01
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

                    b.Property<int?>("InstituicaoID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int?>("TurmaID")
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

            modelBuilder.Entity("IPAGEBiblioteca.Models.EditoraModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PaisID")
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

            modelBuilder.Entity("IPAGEBiblioteca.Models.LivrosModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EditoraModelsID")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("autoModelsID")
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

                    b.Property<bool>("UsuariosConsultas")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuariosRegistar")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.TurmaModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClasseModelsID")
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
                        .HasForeignKey("InstituicaoID");

                    b.HasOne("IPAGEBiblioteca.Models.TurmaModels", "Turma")
                        .WithMany("AlunoModels")
                        .HasForeignKey("TurmaID");
                });

            modelBuilder.Entity("IPAGEBiblioteca.Models.EditoraModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.PaisModels", "Pais")
                        .WithMany("EditoraModels")
                        .HasForeignKey("PaisID");
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
                        .HasForeignKey("EditoraModelsID");

                    b.HasOne("IPAGEBiblioteca.Models.AutorModels", "autoModels")
                        .WithMany("LivrosModels")
                        .HasForeignKey("autoModelsID");
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

            modelBuilder.Entity("IPAGEBiblioteca.Models.TurmaModels", b =>
                {
                    b.HasOne("IPAGEBiblioteca.Models.ClasseModels", "ClasseModels")
                        .WithMany("TurmaModels")
                        .HasForeignKey("ClasseModelsID");
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
