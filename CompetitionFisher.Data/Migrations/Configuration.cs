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

            // GENERATE TEST DATA


            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            var competitionId1 = Guid.NewGuid();
            var competitionId3 = Guid.NewGuid();

            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();
            var userId6 = Guid.NewGuid();
            var userId7 = Guid.NewGuid();

            var resultId1 = Guid.NewGuid();
            var resultId2 = Guid.NewGuid();
            var resultId3 = Guid.NewGuid();
            var resultId4 = Guid.NewGuid();
            var resultId5 = Guid.NewGuid();
            var resultId6 = Guid.NewGuid();
            var resultId7 = Guid.NewGuid();

            // Users & ApplicationUsers
            context.Users.AddOrUpdate(
                el => new { el.FirstName, el.LastName },
                new User { Id = userId1, FirstName = "Tim", LastName = "Martens", ApplicationUser = new ApplicationUser { Id = userId1, FaceBookId = "SomeId1" } },
                new User { Id = userId2, FirstName = "Eddy", LastName = "Pauwels", ApplicationUser = new ApplicationUser { Id = userId2, FaceBookId = "SomeId2" } },
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

            var admin1 = context.ApplicationUsers.Find(userId1);
            var admin2 = context.ApplicationUsers.Find(userId2);

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
                            Id = competitionId1,
                            Name = "Wedstrijd 1",
                            Date = new DateTime(2017, 1, 23),
                            Users = new List<User>
                            {
                                user1, user2, user3, user4, user5, user6
                            },
                            Admins = new List<ApplicationUser>
                            {
                                admin1, admin2
                            },
                            Results = new List<Result>
                            {
                                new Result {Id = resultId1, TotalNumber = 10, TotalWeight = 1230, CompetitionId = competitionId1, UserId = userId1 },
                                new Result {Id = resultId2, TotalNumber = 7, TotalWeight = 940, CompetitionId = competitionId1, UserId = userId2 },
                                new Result {Id = resultId3, TotalNumber = 13, TotalWeight = 2810, CompetitionId = competitionId1, UserId = userId3 },
                                new Result {Id = resultId4, TotalNumber = 0, TotalWeight = 0, CompetitionId = competitionId1, UserId = userId4 },
                                new Result {Id = resultId5, TotalNumber = 6, TotalWeight = 670, CompetitionId = competitionId1, UserId = userId5 },
                                new Result {Id = resultId6, TotalNumber = 12, TotalWeight = 1690, CompetitionId = competitionId1, UserId = userId6 }
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
                            },
                            Admins = new List<ApplicationUser>
                            {
                                admin1, admin2
                            }
                            // No results yet
                        }
                    },
                    Admins = new List<ApplicationUser>
                    {
                        admin1, admin2
                    }
                });

            // add Competition without Championship
            context.Competitions.AddOrUpdate(
                el => el.Name,
                new Competition
                {
                    Id = competitionId3,
                    Name = "Wedstrijd zonder kampioenschap",
                    Date = new DateTime(2017, 3, 6),
                    Users = new List<User>
                    {
                        user1, user2, user3, user4, user5, user6, user7
                    },
                    Admins = new List<ApplicationUser>
                    {
                        admin1
                    },
                    Results = new List<Result>
                    {
                        new Result {Id = Guid.NewGuid(), TotalNumber = 1, TotalWeight = 123, CompetitionId = competitionId3, UserId = userId1 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 18, TotalWeight = 2390, CompetitionId = competitionId3, UserId = userId2 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 18, TotalWeight = 3200, CompetitionId = competitionId3, UserId = userId3 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 10, TotalWeight = 1435, CompetitionId = competitionId3, UserId = userId4 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 23, TotalWeight = 3450, CompetitionId = competitionId3, UserId = userId5 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 7, TotalWeight = 2690, CompetitionId = competitionId3, UserId = userId6 }
                    }
                });


        }
    }
}
