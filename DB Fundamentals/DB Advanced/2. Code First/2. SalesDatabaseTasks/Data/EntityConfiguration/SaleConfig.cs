namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);

            builder.Property(s => s.Date).HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.Product).WithMany(p => p.Sales).HasForeignKey(p => p.SaleId);

            builder.HasOne(s => s.Customer).WithMany(p => p.Sales).HasForeignKey(p => p.SaleId);

            builder.HasOne(s => s.Store).WithMany(p => p.Sales).HasForeignKey(p => p.SaleId);
        }
    }
}

