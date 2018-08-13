namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(p => p.PaymentMethodId);

            builder.Property(x => x.Type).IsRequired(true);

            builder.Property(x => x.UserId).IsRequired(true);

            builder.HasOne(x => x.BankAccount).WithOne(x => x.PaymentMethod).HasForeignKey<PaymentMethod>(x => x.BankAccountId);

            builder.HasOne(x => x.CreditCard).WithOne(x => x.PaymentMethod).HasForeignKey<PaymentMethod>(x => x.CreditCardId);

            builder.HasIndex(x => new { x.UserId, x.BankAccountId, x.CreditCardId }).IsUnique();
        }
    }
}
