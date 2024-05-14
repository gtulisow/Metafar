using atm.api.domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.data.EntityConfigurations
{
    public class CardEntityTypeConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(16);
            builder.Property(c => c.PIN).IsRequired().HasMaxLength(4);
            builder.Property(c => c.Balance).HasColumnType("decimal(18,2)");
            builder.Property(c => c.Enabled).IsRequired();
        }
    }
}
