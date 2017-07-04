using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompetitionFisher.Data.Entities;

namespace CompetitionFisher.Data.EntityConfiguration
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            //ResultId
            HasKey<Guid>(el => el.ResultId);
            Property(el => el.ResultId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.


            //FishermanId 
            //Fisherman 

            //CompetitionId 
            //Competition

            //NbrCaught

            //Weight 

        }
    }
}
