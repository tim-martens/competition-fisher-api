namespace CompetitionFisher.Data.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<CfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CfContext context)
        {
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();
            var userId6 = Guid.NewGuid();
            var userId7 = Guid.NewGuid();

            // GENERATE TEST DATA
            // Users & ApplicationUsers
            context.Users.AddOrUpdate(
                el => new { el.FirstName, el.LastName },
                new User { Id = userId1, FirstName = "Tim", LastName = "Martens", ApplicationUser = new ApplicationUser { FaceBookId = "SomeId1" } },
                new User { Id = userId2, FirstName = "Eddy", LastName = "Pauwels", ApplicationUser = new ApplicationUser { FaceBookId = "SomeId2" } },
                new User { Id = userId3, FirstName = "Peter", LastName = "Martens" },
                new User { Id = userId4, FirstName = "Johan", LastName = "Van Ginderen" },
                new User { Id = userId5, FirstName = "Werner", LastName = "Janssens" },
                new User { Id = userId6, FirstName = "Quinten", LastName = "Van Ginderen" },
                new User { Id = userId7, FirstName = "Patrick", LastName = "Vanotterdyck" }
                );

            var user1 = context.Users.Find(userId1);
            var user2 = context.Users.Find(userId2);
            var user3 = context.Users.Find(userId3);
            var user4 = context.Users.Find(userId4);
            var user5 = context.Users.Find(userId5);
            var user6 = context.Users.Find(userId6);
            var user7 = context.Users.Find(userId7);

            // Championship & Competitions
            context.Championships.AddOrUpdate(
                el => el.Name,
                new Championship
                {
                    Id = Guid.NewGuid(),
                    Name = "TEST Umicore 2015",
                    Competitions = new List<Competition>()
                    {
                        new Competition
                        {
                            Id = Guid.NewGuid(),
                            Name = "Wedstrijd 1",
                            Date = new DateTime(2017, 1, 23),
                            Users = new List<User>
                            {
                                user1, user2, user3, user4, user5, user6
                            }
                        },
                        new Competition
                        {
                            Id = Guid.NewGuid(),
                            Name = "Wedstrijd 2",
                            Date = new DateTime(2017, 2, 17),
                            Users = new List<User>
                            {
                                user1, user2, user3, user5, user7
                            }
                        }
                    }});

            // add Competition without Championship
            context.Competitions.AddOrUpdate(
                el => el.Name,
                new Competition
                {
                    Id = Guid.NewGuid(),
                    Name = "Wedstrijd zonder kampioenschap",
                    Date = new DateTime(2017, 3, 6),
                    Users =new List<User>
                    {
                        user1, user2, user3, user4, user5, user6, user7
                    }
                });

            
        }
    }
}
