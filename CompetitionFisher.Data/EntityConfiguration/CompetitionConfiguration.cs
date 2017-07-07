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
            Property(el => el.Name).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //Date
            Property(el => el.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0); ;

            //Users
            HasMany(f => f.Users)
                .WithMany(c => c.Competitions)
                .Map(uc =>
                {
                    uc.ToTable("UsersCompetitions");
                    uc.MapRightKey("UserId");
                    uc.MapLeftKey("CompetitionId");
                });

            //Championship
            //HasOptional(el => el.Championship)
            //    .WithMany(c => c.Competitions)
            //    .HasForeignKey(c => c.ChampionshipId);

        }
    }
}
