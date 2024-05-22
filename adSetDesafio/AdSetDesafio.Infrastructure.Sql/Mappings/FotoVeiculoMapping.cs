using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdSetDesafio.Domain.Common.Entities;

namespace AdSetDesafio.Infrastructure.Sql.Mappings
{
    public class FotoVeiculoMapping : IEntityTypeConfiguration<FotoVeiculo>
    {
        public void Configure(EntityTypeBuilder<FotoVeiculo> builder)
        {
            builder.ToTable("FotoVeiculo");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.IdVeiculo).IsRequired();
            builder.Property(c => c.IdGuid).IsRequired();
            builder.Property(c => c.Arquivo).IsRequired();
            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();

            //object value = builder.HasOne<int>(d => d.IdVeiculo)
            //    .WithMany(p => p.FotoVeiculo)
            //    .HasForeignKey(d => d.IdVeiculo);
        }
    }
}