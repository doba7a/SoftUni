namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name).HasMaxLength(100).IsUnicode();

            builder.Property(s => s.PhoneNumber).HasMaxLength(10).IsFixedLength(true).IsUnicode(false).IsRequired(false);

            builder.Property(s => s.Birthday).IsRequired(false);

            builder.HasMany(s => s.HomeworkSubmissions).WithOne(hs => hs.Student).HasForeignKey(hs => hs.StudentId);

            builder.HasMany(s => s.CourseEnrollments).WithOne(ce => ce.Student).HasForeignKey(ce => ce.StudentId);
        }
    }
}
