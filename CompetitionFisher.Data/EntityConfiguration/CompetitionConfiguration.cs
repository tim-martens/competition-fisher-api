using CompetitionFisher.Data.Entities;
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

            //Date
            Property(el => el.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0); ;

            //ChampionshipId
            //Championship

            //Fishermen
            HasMany(f => f.Fishermen)
                .WithMany(c => c.Competitions)
                .Map(fc =>
                {
                    fc.ToTable("FishermenCompetitions");
                    fc.MapLeftKey("CompetitionId");
                    fc.MapRightKey("FishermanId");
                });

        }
    }
}
