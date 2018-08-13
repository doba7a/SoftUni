namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.Name).HasMaxLength(50).IsUnicode();

            builder.Property(r => r.Url).IsUnicode(false);

            builder.HasOne(r => r.Course).WithMany(c => c.Resources).HasForeignKey(c => c.ResourceId);
        }
    }
}
