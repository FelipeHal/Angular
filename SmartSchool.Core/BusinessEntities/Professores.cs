using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.BusinessEntities
{
    public class Professores
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Disciplinas> Disciplinas { get; set; }
    }

    public class ProfessorConfiguration : IEntityTypeConfiguration<Professores>
    {
        public void Configure(EntityTypeBuilder<Professores> builder)
        {
            builder
                .HasData(new List<Professores>(){
                    new Professores { Id = 1, Nome = "Lauro" },
                    new Professores { Id = 2, Nome = "Roberto" },
                    new Professores { Id = 3, Nome = "Ronaldo" },
                    new Professores { Id = 4, Nome = "Rodrigo" },
                    new Professores { Id = 5, Nome = "Alexandre" },
                });
        }
    }
}