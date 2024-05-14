using atm.api.domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace atm.api.data.EntityConfigurations
{
    public class OperationTypeEntityTypeConfig : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.ToTable("OperationTypes");
            builder.HasKey(ot => ot.Id);
            builder.Property(ot => ot.Name).IsRequired().HasMaxLength(50);
            builder.Property(ot => ot.Description).IsRequired().HasMaxLength(100);
        }
    }
}
