namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(b => b.BankAccountId);

            builder.Property(b => b.Balance).IsRequired(true);

            builder.Property(x => x.BankName).HasMaxLength(50).IsUnicode(true).IsRequired(true);

            builder.Property(x => x.SWIFTCode).HasMaxLength(20).IsUnicode(false).IsRequired(true);

            builder.Ignore(b => b.PaymentMethodId);
        }
    }
}
