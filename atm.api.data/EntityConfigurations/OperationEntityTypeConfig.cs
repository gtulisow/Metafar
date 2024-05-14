using atm.api.domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace atm.api.data.EntityConfigurations
{
    public class OperationEntityTypeConfig : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Operations");
            builder.HasKey(o => o.Id);


            // Relación con Card
            builder.Property(o => o.CardId).IsRequired();
            builder.HasOne(o => o.Card)
                   .WithMany()
                   .HasForeignKey(o => o.CardId)
                   .IsRequired();

            // Relación con OperationType
            builder.Property(o => o.OperationTypeId).IsRequired();
            builder.HasOne(o => o.OperationType)
                   .WithMany()
                   .HasForeignKey(o => o.OperationTypeId)
                   .IsRequired();

            builder.Property(o => o.Amount).HasColumnType("decimal(18,2)");
            builder.Property(o => o.OperationDateTime).IsRequired();
        }
    }
}
