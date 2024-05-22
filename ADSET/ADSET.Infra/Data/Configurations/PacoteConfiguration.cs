using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class PacoteConfiguration : IEntityTypeConfiguration<Pacote>
    {
        public void Configure(EntityTypeBuilder<Pacote> builder)
        {
            builder.ToTable("Pacotes");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Tipo)
            .IsRequired();

            builder.Property(f => f.IsActive).HasDefaultValue(true);

            builder.Property(f => f.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(f => f.DateUpdated).HasDefaultValue(null);

            builder.HasOne(f => f.Veiculo)
                   .WithMany(f => f.Pacotes)
                   .HasForeignKey(f => f.VeiculoId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
