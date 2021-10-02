﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.Core;

namespace SmartSchool.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211002000401_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Alunos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Marta",
                            Sobrenome = "Kent",
                            Telefone = "34556456"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "34556423"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "34556465"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "34556487"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "34556462"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "34556472"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "34556494"
                        });
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.AlunosDisciplinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlunoId = 1,
                            DisciplinaId = 2
                        },
                        new
                        {
                            Id = 2,
                            AlunoId = 1,
                            DisciplinaId = 4
                        },
                        new
                        {
                            Id = 3,
                            AlunoId = 1,
                            DisciplinaId = 5
                        },
                        new
                        {
                            Id = 4,
                            AlunoId = 2,
                            DisciplinaId = 1
                        },
                        new
                        {
                            Id = 5,
                            AlunoId = 2,
                            DisciplinaId = 2
                        },
                        new
                        {
                            Id = 6,
                            AlunoId = 2,
                            DisciplinaId = 5
                        },
                        new
                        {
                            Id = 7,
                            AlunoId = 3,
                            DisciplinaId = 1
                        },
                        new
                        {
                            Id = 8,
                            AlunoId = 3,
                            DisciplinaId = 2
                        },
                        new
                        {
                            Id = 9,
                            AlunoId = 3,
                            DisciplinaId = 3
                        },
                        new
                        {
                            Id = 10,
                            AlunoId = 4,
                            DisciplinaId = 1
                        },
                        new
                        {
                            Id = 11,
                            AlunoId = 4,
                            DisciplinaId = 4
                        },
                        new
                        {
                            Id = 12,
                            AlunoId = 4,
                            DisciplinaId = 5
                        },
                        new
                        {
                            Id = 13,
                            AlunoId = 5,
                            DisciplinaId = 4
                        },
                        new
                        {
                            Id = 14,
                            AlunoId = 5,
                            DisciplinaId = 5
                        },
                        new
                        {
                            Id = 15,
                            AlunoId = 6,
                            DisciplinaId = 1
                        },
                        new
                        {
                            Id = 16,
                            AlunoId = 6,
                            DisciplinaId = 2
                        },
                        new
                        {
                            Id = 17,
                            AlunoId = 6,
                            DisciplinaId = 3
                        },
                        new
                        {
                            Id = 18,
                            AlunoId = 6,
                            DisciplinaId = 4
                        },
                        new
                        {
                            Id = 19,
                            AlunoId = 7,
                            DisciplinaId = 1
                        },
                        new
                        {
                            Id = 20,
                            AlunoId = 7,
                            DisciplinaId = 2
                        },
                        new
                        {
                            Id = 21,
                            AlunoId = 7,
                            DisciplinaId = 3
                        },
                        new
                        {
                            Id = 22,
                            AlunoId = 7,
                            DisciplinaId = 4
                        },
                        new
                        {
                            Id = 23,
                            AlunoId = 7,
                            DisciplinaId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Disciplinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Professores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Alexandre"
                        });
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SenhaHash")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Usuario")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Usuário demo",
                            SenhaHash = "E4HTxoLdCoV49AYzf+vx84EhR3VXBIJqfAXDgFE57vmAOteMobsfYef27rrRHymm",
                            Usuario = "teste"
                        });
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.AlunosDisciplinas", b =>
                {
                    b.HasOne("SmartSchool.Core.BusinessEntities.Alunos", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.Core.BusinessEntities.Disciplinas", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Disciplinas", b =>
                {
                    b.HasOne("SmartSchool.Core.BusinessEntities.Professores", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Alunos", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Disciplinas", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.Core.BusinessEntities.Professores", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}