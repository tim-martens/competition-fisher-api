namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FaceBookId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "UX_Competitor_FirstName_LastName");
            
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChampionshipId = c.Guid(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Championship", t => t.ChampionshipId)
                .Index(t => t.ChampionshipId);
            
            CreateTable(
                "dbo.Championship",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersCompetitions",
                c => new
                    {
                        CompetitionId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitionId, t.UserId })
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersCompetitions", "UserId", "dbo.User");
            DropForeignKey("dbo.UsersCompetitions", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Competition", "ChampionshipId", "dbo.Championship");
            DropForeignKey("dbo.ApplicationUser", "UserId", "dbo.User");
            DropIndex("dbo.UsersCompetitions", new[] { "UserId" });
            DropIndex("dbo.UsersCompetitions", new[] { "CompetitionId" });
            DropIndex("dbo.Competition", new[] { "ChampionshipId" });
            DropIndex("dbo.User", "UX_Competitor_FirstName_LastName");
            DropIndex("dbo.ApplicationUser", new[] { "UserId" });
            DropTable("dbo.UsersCompetitions");
            DropTable("dbo.Championship");
            DropTable("dbo.Competition");
            DropTable("dbo.User");
            DropTable("dbo.ApplicationUser");
        }
    }
}
