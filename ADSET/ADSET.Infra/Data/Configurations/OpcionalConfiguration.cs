using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class OpcionalConfiguration : IEntityTypeConfiguration<Opcional>
    {
        public void Configure(EntityTypeBuilder<Opcional> builder)
        {
            builder.ToTable("Opcionais");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.IsActive).HasDefaultValue(true);

            builder.Property(v => v.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(v => v.DateUpdated).HasDefaultValue(null);
        }
    }
}
