using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Ano)
                .IsRequired()
                .HasMaxLength(9999);

            builder.Property(v => v.Cor)
                .IsRequired();

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(v => v.Km)
                .HasDefaultValue(0)
                .HasMaxLength(9999);

            builder.Property(v => v.Preco)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(v => v.HaveFoto).HasDefaultValue(false);

            builder.Property(v => v.IsActive).HasDefaultValue(true);

            builder.Property(v => v.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(v => v.DateUpdated).HasDefaultValue(null);

            builder.HasOne(v => v.Marca)
                    .WithMany(v => v.Veiculos)
                    .HasForeignKey(v => v.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(v => v.Modelo)
                    .WithMany(v => v.Veiculos)
                    .HasForeignKey(v => v.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
