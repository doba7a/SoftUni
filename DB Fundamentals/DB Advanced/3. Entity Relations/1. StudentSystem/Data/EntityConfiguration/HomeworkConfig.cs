namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfig : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(h => h.HomeworkId);

            builder.Property(h => h.Content).IsUnicode(false);

            builder.HasOne(h => h.Student).WithMany(s => s.HomeworkSubmissions).HasForeignKey(s => s.HomeworkId);

            builder.HasOne(h => h.Course).WithMany(c => c.HomeworkSubmissions).HasForeignKey(c => c.HomeworkId);
        }
    }
}

