namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Date = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        ChampionshipId = c.Guid(nullable: false),
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
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "UX_ApplicationUser_FirstName_LastName");
            
            CreateTable(
                "dbo.Competitor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "UX_Competitor_FirstName_LastName");
            
            CreateTable(
                "dbo.AdminsPerChampionship",
                c => new
                    {
                        ApplicationUserId = c.Guid(nullable: false),
                        ChampionshipId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ChampionshipId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Championship", t => t.ChampionshipId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ChampionshipId);
            
            CreateTable(
                "dbo.CompetitionsPerCompetitor",
                c => new
                    {
                        CompetitorId = c.Guid(nullable: false),
                        CompetitionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitorId, t.CompetitionId })
                .ForeignKey("dbo.Competition", t => t.CompetitorId, cascadeDelete: true)
                .ForeignKey("dbo.Competitor", t => t.CompetitionId, cascadeDelete: true)
                .Index(t => t.CompetitorId)
                .Index(t => t.CompetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompetitionsPerCompetitor", "CompetitionId", "dbo.Competitor");
            DropForeignKey("dbo.CompetitionsPerCompetitor", "CompetitorId", "dbo.Competition");
            DropForeignKey("dbo.Competition", "ChampionshipId", "dbo.Championship");
            DropForeignKey("dbo.AdminsPerChampionship", "ChampionshipId", "dbo.Championship");
            DropForeignKey("dbo.AdminsPerChampionship", "ApplicationUserId", "dbo.ApplicationUser");
            DropIndex("dbo.CompetitionsPerCompetitor", new[] { "CompetitionId" });
            DropIndex("dbo.CompetitionsPerCompetitor", new[] { "CompetitorId" });
            DropIndex("dbo.AdminsPerChampionship", new[] { "ChampionshipId" });
            DropIndex("dbo.AdminsPerChampionship", new[] { "ApplicationUserId" });
            DropIndex("dbo.Competitor", "UX_Competitor_FirstName_LastName");
            DropIndex("dbo.ApplicationUser", "UX_ApplicationUser_FirstName_LastName");
            DropIndex("dbo.Competition", new[] { "ChampionshipId" });
            DropTable("dbo.CompetitionsPerCompetitor");
            DropTable("dbo.AdminsPerChampionship");
            DropTable("dbo.Competitor");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Championship");
            DropTable("dbo.Competition");
        }
    }
}
