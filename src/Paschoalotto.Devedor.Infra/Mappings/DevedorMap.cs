using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Devedor.Domain.Models.Database;

namespace Paschoalotto.Devedor.Infra.Mappings
{
    public class DevedorMap : IEntityTypeConfiguration<Domain.Models.Database.Devedor>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Database.Devedor> builder)
        {
            builder.ToTable("Devedor", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR(250)")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasMany(x => x.Parcela)
                .WithOne(x => x.Devedor)
                .HasForeignKey(x => x.DevedorId);
        }
    }
}
