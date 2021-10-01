using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.BusinessEntities
{
    public class AlunosDisciplinas
    {
        [Key]
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public virtual Alunos Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public virtual Disciplinas Disciplina { get; set; }
    }

    public class AlunoDisciplinaConfiguration : IEntityTypeConfiguration<AlunosDisciplinas>
    {
        public void Configure(EntityTypeBuilder<AlunosDisciplinas> builder)
        {
            builder
                .HasData(new List<AlunosDisciplinas>() {
                    new AlunosDisciplinas() { Id = 1, AlunoId = 1, DisciplinaId = 2 },
                    new AlunosDisciplinas() { Id = 2, AlunoId = 1, DisciplinaId = 4 },
                    new AlunosDisciplinas() { Id = 3, AlunoId = 1, DisciplinaId = 5 },
                    new AlunosDisciplinas() { Id = 4, AlunoId = 2, DisciplinaId = 1 },
                    new AlunosDisciplinas() { Id = 5, AlunoId = 2, DisciplinaId = 2 },
                    new AlunosDisciplinas() { Id = 6, AlunoId = 2, DisciplinaId = 5 },
                    new AlunosDisciplinas() { Id = 7, AlunoId = 3, DisciplinaId = 1 },
                    new AlunosDisciplinas() { Id = 8, AlunoId = 3, DisciplinaId = 2 },
                    new AlunosDisciplinas() { Id = 9, AlunoId = 3, DisciplinaId = 3 },
                    new AlunosDisciplinas() { Id = 10, AlunoId = 4, DisciplinaId = 1 },
                    new AlunosDisciplinas() { Id = 11, AlunoId = 4, DisciplinaId = 4 },
                    new AlunosDisciplinas() { Id = 12, AlunoId = 4, DisciplinaId = 5 },
                    new AlunosDisciplinas() { Id = 13, AlunoId = 5, DisciplinaId = 4 },
                    new AlunosDisciplinas() { Id = 14, AlunoId = 5, DisciplinaId = 5 },
                    new AlunosDisciplinas() { Id = 15, AlunoId = 6, DisciplinaId = 1 },
                    new AlunosDisciplinas() { Id = 16, AlunoId = 6, DisciplinaId = 2 },
                    new AlunosDisciplinas() { Id = 17, AlunoId = 6, DisciplinaId = 3 },
                    new AlunosDisciplinas() { Id = 18, AlunoId = 6, DisciplinaId = 4 },
                    new AlunosDisciplinas() { Id = 19, AlunoId = 7, DisciplinaId = 1 },
                    new AlunosDisciplinas() { Id = 20, AlunoId = 7, DisciplinaId = 2 },
                    new AlunosDisciplinas() { Id = 21, AlunoId = 7, DisciplinaId = 3 },
                    new AlunosDisciplinas() { Id = 22, AlunoId = 7, DisciplinaId = 4 },
                    new AlunosDisciplinas() { Id = 23, AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}