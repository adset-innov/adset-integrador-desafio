using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.IsActive).HasDefaultValue(true);

            builder.Property(m => m.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(m => m.DateUpdated).HasDefaultValue(null);
        }
    }
}
