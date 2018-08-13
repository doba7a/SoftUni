namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(d => d.Comments);

            builder.Property(d => d.Name).HasMaxLength(50).IsUnicode();

            builder.Property(d => d.Comments).HasMaxLength(250).IsUnicode();

            builder.HasOne(d => d.Patient).WithMany(p => p.Diagnoses).HasForeignKey(p => p.DiagnoseId);
        }
    }
}
