namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name).HasMaxLength(80).IsUnicode();

            builder.Property(c => c.Description).IsUnicode().IsRequired(false);

            builder.HasMany(c => c.StudentsEnrolled).WithOne(se => se.Course).HasForeignKey(se => se.CourseId);

            builder.HasMany(c => c.Resources).WithOne(r => r.Course).HasForeignKey(r => r.CourseId);

            builder.HasMany(c => c.HomeworkSubmissions).WithOne(hs => hs.Course).HasForeignKey(hs => hs.CourseId);
        }
    }
}
