using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.BusinessEntities
{
    public class Disciplinas
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professores Professor { get; set; }
        public virtual IEnumerable<AlunosDisciplinas> AlunosDisciplinas { get; set; }
    }

    public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplinas>
    {
        public void Configure(EntityTypeBuilder<Disciplinas> builder)
        {
            builder
                .HasData(new List<Disciplinas>{
                    new Disciplinas { Id = 1, Nome = "Matem�tica", ProfessorId = 1 },
                    new Disciplinas { Id = 2, Nome = "F�sica", ProfessorId = 2},
                    new Disciplinas { Id = 3, Nome = "Portugu�s", ProfessorId = 3},
                    new Disciplinas { Id = 4, Nome = "Ingl�s", ProfessorId = 4},
                    new Disciplinas { Id = 5, Nome = "Programa��o", ProfessorId = 5}
                });
        }
    }
}