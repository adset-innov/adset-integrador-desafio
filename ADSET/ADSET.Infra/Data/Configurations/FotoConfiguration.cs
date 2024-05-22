using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("Fotos");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Caminho)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(f => f.IsActive).HasDefaultValue(true);

            builder.Property(f => f.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(f => f.DateUpdated).HasDefaultValue(null);

            builder.HasOne(f => f.Veiculo)
                   .WithMany(f => f.Fotos)
                   .HasForeignKey(f => f.VeiculoId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
