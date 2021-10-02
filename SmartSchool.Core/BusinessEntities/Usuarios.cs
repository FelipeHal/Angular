using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSchool.Core.Helper.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Core.BusinessEntities
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Usuario { get; set; }

        [StringLength(200)]
        public string SenhaHash { get; set; }
    }

    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder
                .HasData(new [] {
                    new Usuarios { Id = 1, Nome = "Usuário demo", Usuario = "teste1", SenhaHash = PasswordHasher.HashPassword("123456") },
                });
        }
    }
}
