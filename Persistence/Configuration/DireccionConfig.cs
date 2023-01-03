using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DireccionConfig : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direcciones");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Alias)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.CalleNumero)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Colonia)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.CodigoPostal)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(p => p.Ciudad)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Pais)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(30);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
