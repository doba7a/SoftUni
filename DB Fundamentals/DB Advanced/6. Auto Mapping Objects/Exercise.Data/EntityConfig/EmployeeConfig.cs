namespace Exercise.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Exercise.Models;

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName).HasMaxLength(30).IsUnicode(true).IsRequired(true);

            builder.Property(e => e.LastName).HasMaxLength(30).IsUnicode(true).IsRequired(true);
        
            builder.Property(e => e.Salary).IsRequired(true);

            builder.Property(e => e.Address).HasMaxLength(30).IsUnicode(true);
        }
    }
}
