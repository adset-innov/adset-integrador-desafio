using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(m => m.IsActive).HasDefaultValue(true);

            builder.Property(m => m.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(m => m.DateUpdated).HasDefaultValue(null);

            builder.HasOne(m => m.Marca)
                   .WithMany(m => m.Modelos)
                   .HasForeignKey(m => m.MarcaId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
