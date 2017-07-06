using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
using CompetitionFisher.Data.EntityConfiguration.Code.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //FirstName
            Property(el => el.FirstName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasUniqueIndexAnnotation("UX_ApplicationUser_FirstName_LastName", EntityConfigurationConstants.FIRST_INDEX_COLUMN);

            //LastName
            Property(el => el.LastName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasUniqueIndexAnnotation("UX_ApplicationUser_FirstName_LastName", EntityConfigurationConstants.SECOND_INDEX_COLUMN); ;

            //Championships
            HasMany(u => u.Championships)
              .WithMany(c => c.Admins)
              .Map(ca =>
              {
                  ca.ToTable("AdminsPerChampionship");
                  ca.MapLeftKey("ApplicationUserId");
                  ca.MapRightKey("ChampionshipId");
              });
            
        }
        
    }
}
