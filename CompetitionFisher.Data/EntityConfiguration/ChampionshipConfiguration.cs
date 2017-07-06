using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class ChampionshipConfiguration : EntityTypeConfiguration<Championship>
    {
        public ChampionshipConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //Name
            Property(el => el.Name).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //Admins
            HasMany(c => c.Admins)
               .WithMany(a => a.Championships)
               .Map(ca =>
               {
                   ca.ToTable("AdminsPerChampionship");
                   ca.MapLeftKey("ApplicationUserId");
                   ca.MapRightKey("ChampionshipId");
               });

            //Competitions
            
        }
    }
}
