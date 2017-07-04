using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompetitionFisher.Data.Entities;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {
            //CompetitionId
            HasKey(el => el.CompetitionId);
            Property(el => el.CompetitionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //CompetitionDate
            Property(el => el.CompetitionDate).IsRequired();

            //Fishermen
            HasMany(f => f.Fishermen)
                .WithMany(c => c.Competitions)
                .Map(fc =>
                {
                    fc.ToTable("FishermenCompetitions");
                    fc.MapLeftKey("CompetitionId");
                    fc.MapRightKey("FishermanId");
                });

            //Results
        }
    }
}
