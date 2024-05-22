using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADSET.Infra.Data.Configurations
{
    public class VeiculoOpcionalConfiguration : IEntityTypeConfiguration<VeiculoOpcional>
    {
        public void Configure(EntityTypeBuilder<VeiculoOpcional> builder)
        {
            builder.ToTable(nameof(VeiculoOpcional));

            builder.HasKey(ov => ov.Id);

            builder.Property(ov => ov.IsActive).HasDefaultValue(true);

            builder.Property(ov => ov.DateCreated).HasDefaultValue(DateTime.Now);

            builder.Property(ov => ov.DateUpdated).HasDefaultValue(null);

            builder.HasOne(ov => ov.Veiculo)
                    .WithMany(ov => ov.VeiculoOpcionais)
                    .HasForeignKey(ov => ov.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(ov => ov.Opcional)
                    .WithMany(ov => ov.VeiculoOpcionais)
                    .HasForeignKey(ov => ov.OpcionalId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
