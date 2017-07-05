using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class FishermanConfiguration : EntityTypeConfiguration<Fisherman>
    {
        public FishermanConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //FirstName
            Property(el => el.FirstName).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //LastName
            Property(el => el.LastName).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //Competitions
        }
    }
}
