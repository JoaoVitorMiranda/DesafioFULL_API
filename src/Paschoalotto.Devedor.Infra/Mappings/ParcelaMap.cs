using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Devedor.Domain.Models;

namespace Paschoalotto.Devedor.Infra.Mappings
{
    public class ParcelaMap : IEntityTypeConfiguration<Domain.Models.Database.Parcela>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Database.Parcela> builder)
        {
            builder.ToTable("Parcela", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Vencimento)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.HasOne(x => x.Devedor)
                .WithMany(x => x.Parcela)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
