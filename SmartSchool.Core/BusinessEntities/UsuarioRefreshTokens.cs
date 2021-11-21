using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Core.BusinessEntities
{
    public class UsuarioRefreshTokens
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expiration;

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;
    }

    public class UsuarioRefreshTokensConfiguration : IEntityTypeConfiguration<UsuarioRefreshTokens>
    {
        public void Configure(EntityTypeBuilder<UsuarioRefreshTokens> builder)
        {
            
        }
    }
}