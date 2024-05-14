using atm.api.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace atm.api.data.EntityConfigurations
{
    public class UserAccountEntityTypeConfig : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("UserAccounts");
            builder.HasKey(a => a.Id);
            
            builder.HasOne(a => a.Card)
                   .WithMany()
                   .HasForeignKey(a => a.CardId)
                   .IsRequired();

            builder.Property(a => a.Name).IsRequired().HasMaxLength(100); 
            builder.Property(a => a.LastAccessDate).IsRequired();
            builder.Property(a => a.FailedAccessAttempts).IsRequired();
        }
    }
   
}
