using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdSetDesafio.Domain.Common.Entities;

namespace AdSetDesafio.Infrastructure.Sql.Mappings
{
    public class OpcionalMapping : IEntityTypeConfiguration<Opcional>
    {
        public void Configure(EntityTypeBuilder<Opcional> builder)
        {
            builder.ToTable("Opcional");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            
        }
    }
}