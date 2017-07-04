using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompetitionFisher.Data.Entities;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class FishermanConfiguration : EntityTypeConfiguration<Fisherman>
    {
        public FishermanConfiguration()
        {
            //FishermanId
            HasKey(el => el.FishermanId);
            Property(el => el.FishermanId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //FirstName
            Property(el => el.FirstName).IsRequired().HasMaxLength(50);

            //LastName
            Property(el => el.LastName).IsRequired().HasMaxLength(50);

            //Competitions
        }
    }
}
