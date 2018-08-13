namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(cl => cl.ColorId);

            builder.HasMany(cl => cl.PrimaryKitTeams).WithOne(pkt => pkt.PrimaryKitColor).HasForeignKey(pkt => pkt.PrimaryKitColorId);

            builder.HasMany(cl => cl.SecondaryKitTeams).WithOne(pkt => pkt.SecondaryKitColor).HasForeignKey(pkt => pkt.SecondaryKitColorId);
        }
    }
}
