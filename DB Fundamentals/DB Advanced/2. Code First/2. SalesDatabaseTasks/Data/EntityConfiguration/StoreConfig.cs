namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(st => st.StoreId);

            builder.Property(st => st.Name).HasMaxLength(80).IsUnicode();

            builder.HasMany(st => st.Sales).WithOne(s => s.Store).HasForeignKey(s => s.StoreId);
        }
    }
}
