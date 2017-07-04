using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration.Extensions;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            //UserId
            HasKey<Guid>(el => el.UserId);
            Property(el => el.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //FirstName
            Property(el => el.FirstName)
                .IsRequired()
                .HasMaxLength(50) //TODO: add constant for this
                .HasUniqueIndexAnnotation("UX_User_FirstName_LastName", 0);

            //LastName
            Property(el => el.LastName)
                .IsRequired()
                .HasMaxLength(50) //TODO: add constant for this
                .HasUniqueIndexAnnotation("UX_User_FirstName_LastName", 1); ;
        }
    }
}
