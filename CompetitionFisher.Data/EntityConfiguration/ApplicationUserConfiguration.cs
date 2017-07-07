using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
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
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None) // Client must set the ID.
                .HasColumnName("UserId"); // PK = FK for one to zero-or-one. see https://www.codeproject.com/Articles/806344/One-to-zero-one-relation-in-entity-framework-code

            //FaceBookId
            Property(el => el.FaceBookId).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            ////Championships
            //HasMany(u => u.Championships)
            //  .WithMany(c => c.Admins)
            //  .Map(ca =>
            //  {
            //      ca.ToTable("AdminsPerChampionship");
            //      ca.MapLeftKey("ApplicationUserId");
            //      ca.MapRightKey("ChampionshipId");
            //  });

        }

    }
}
