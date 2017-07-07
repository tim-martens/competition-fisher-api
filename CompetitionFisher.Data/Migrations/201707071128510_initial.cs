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
                "dbo.Championship",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Result",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompetitionId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        TotalNumber = c.Int(nullable: false),
                        TotalWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Competition", t => t.CompetitionId)
                .Index(t => t.CompetitionId)
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
                "dbo.ChampionshipAdmin",
                c => new
                    {
                        ChampionshipId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChampionshipId, t.UserId })
                .ForeignKey("dbo.Championship", t => t.ChampionshipId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChampionshipId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CompetitionAdmin",
                c => new
                    {
                        CompetitionId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitionId, t.UserId })
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserCompetition",
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
            DropForeignKey("dbo.Competition", "ChampionshipId", "dbo.Championship");
            DropForeignKey("dbo.UserCompetition", "UserId", "dbo.User");
            DropForeignKey("dbo.UserCompetition", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Result", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Result", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUser", "UserId", "dbo.User");
            DropForeignKey("dbo.CompetitionAdmin", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.CompetitionAdmin", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.ChampionshipAdmin", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.ChampionshipAdmin", "ChampionshipId", "dbo.Championship");
            DropIndex("dbo.UserCompetition", new[] { "UserId" });
            DropIndex("dbo.UserCompetition", new[] { "CompetitionId" });
            DropIndex("dbo.CompetitionAdmin", new[] { "UserId" });
            DropIndex("dbo.CompetitionAdmin", new[] { "CompetitionId" });
            DropIndex("dbo.ChampionshipAdmin", new[] { "UserId" });
            DropIndex("dbo.ChampionshipAdmin", new[] { "ChampionshipId" });
            DropIndex("dbo.User", "UX_Competitor_FirstName_LastName");
            DropIndex("dbo.Result", new[] { "UserId" });
            DropIndex("dbo.Result", new[] { "CompetitionId" });
            DropIndex("dbo.Competition", new[] { "ChampionshipId" });
            DropIndex("dbo.ApplicationUser", new[] { "UserId" });
            DropTable("dbo.UserCompetition");
            DropTable("dbo.CompetitionAdmin");
            DropTable("dbo.ChampionshipAdmin");
            DropTable("dbo.User");
            DropTable("dbo.Result");
            DropTable("dbo.Competition");
            DropTable("dbo.Championship");
            DropTable("dbo.ApplicationUser");
        }
    }
}
