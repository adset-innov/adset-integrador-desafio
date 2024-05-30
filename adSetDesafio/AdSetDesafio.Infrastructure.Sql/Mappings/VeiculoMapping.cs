using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdSetDesafio.Domain.Common.Entities;

namespace AdSetDesafio.Infrastructure.Sql.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Marca).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Modelo).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Ano).IsRequired();
            builder.Property(c => c.Placa).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Km);
            builder.Property(c => c.Cor).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Preco).IsRequired();
            builder.Property(c => c.IdOpcional);
            builder.Property(c => c.PacoteICarros);
            builder.Property(c => c.PacoteWebMotors);
            builder.Property(c => c.Fotos);
        }
    }
}