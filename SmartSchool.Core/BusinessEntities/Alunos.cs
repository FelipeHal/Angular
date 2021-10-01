using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.BusinessEntities
{
    public class Alunos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public virtual IEnumerable<AlunosDisciplinas> AlunosDisciplinas { get; set; }
    }

    public class AlunoConfiguration : IEntityTypeConfiguration<Alunos>
    {
        public void Configure(EntityTypeBuilder<Alunos> builder)
        {
            builder
                .HasData(new List<Alunos>(){
                    new Alunos { Id = 1, Nome = "Marta", Sobrenome = "Kent", Telefone = "34556456" },
                    new Alunos { Id = 2, Nome = "Paula", Sobrenome = "Isabela", Telefone = "34556423" },
                    new Alunos { Id = 3, Nome = "Laura", Sobrenome = "Antonia", Telefone = "34556465" },
                    new Alunos { Id = 4, Nome = "Luiza", Sobrenome = "Maria", Telefone = "34556487" },
                    new Alunos { Id = 5, Nome = "Lucas", Sobrenome = "Machado", Telefone = "34556462" },
                    new Alunos { Id = 6, Nome = "Pedro", Sobrenome = "Alvares", Telefone = "34556472" },
                    new Alunos { Id = 7, Nome = "Paulo", Sobrenome = "José", Telefone = "34556494" }
                });
        }
    }
}