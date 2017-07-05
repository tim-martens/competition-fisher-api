﻿using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CompetitionFisher.Data
{
    public class CfContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Fisherman> Fishermen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match singular entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            // entity configurations
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            modelBuilder.Configurations.Add(new FishermanConfiguration());
            modelBuilder.Configurations.Add(new ChampionshipConfiguration());
        }

    }
}
