using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //Name
            Property(el => el.Name).IsOptional().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //Date
            Property(el => el.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0); ;

            //ChampionshipId
            //Championship

            //Fishermen
            HasMany(f => f.Competitors)
                .WithMany(c => c.Competitions)
                .Map(fc =>
                {
                    fc.ToTable("CompetitionsPerCompetitor");
                    fc.MapLeftKey("CompetitorId");
                    fc.MapRightKey("CompetitionId");
                });

        }
    }
}
