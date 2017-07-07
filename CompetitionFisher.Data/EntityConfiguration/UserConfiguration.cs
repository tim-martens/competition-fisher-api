using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Code;
using CompetitionFisher.Data.EntityConfiguration.Code.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //FirstName
            Property(el => el.FirstName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasUniqueIndexAnnotation("UX_Competitor_FirstName_LastName", EntityConfigurationConstants.FIRST_INDEX_COLUMN);

            //LastName
            Property(el => el.LastName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasUniqueIndexAnnotation("UX_Competitor_FirstName_LastName", EntityConfigurationConstants.SECOND_INDEX_COLUMN);

            //ApplicationUser
            HasOptional(el => el.ApplicationUser) // mark ApplicationUser property optional for Competitor
                .WithRequired(el => el.User); // see https://www.codeproject.com/Articles/806344/One-to-zero-one-relation-in-entity-framework-code

            //Competitions
            //configured on other side of relation

            //Results
            HasMany(el => el.Results)
                .WithRequired(r => r.User)
                .HasForeignKey(r => r.UserId);

        }
    }
}
