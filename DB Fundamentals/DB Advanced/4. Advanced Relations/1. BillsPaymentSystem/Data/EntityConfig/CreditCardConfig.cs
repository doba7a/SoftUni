namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(c => c.CreditCardId);

            builder.Property(c => c.Limit).IsRequired(true);

            builder.Property(c => c.MoneyOwed).IsRequired(true);

            builder.Property(c => c.ExpirationDate).IsRequired(true);

            builder.Ignore(c => c.LimitLeft);

            builder.Ignore(c => c.PaymentMethodId);
        }
    }
}
