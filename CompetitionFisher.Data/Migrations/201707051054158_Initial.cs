namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompetitionDate = c.DateTime(nullable: false),
                        Championship_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Championship", t => t.Championship_Id)
                .Index(t => t.Championship_Id);
            
            CreateTable(
                "dbo.Fisherman",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "UX_User_FirstName_LastName");
            
            CreateTable(
                "dbo.Championship",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FishermenCompetitions",
                c => new
                    {
                        CompetitionId = c.Guid(nullable: false),
                        FishermanId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitionId, t.FishermanId })
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Fisherman", t => t.FishermanId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.FishermanId);
            
            CreateTable(
                "dbo.ChampionshipsAdmins",
                c => new
                    {
                        ChampionshipId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChampionshipId, t.UserId })
                .ForeignKey("dbo.User", t => t.ChampionshipId, cascadeDelete: true)
                .ForeignKey("dbo.Championship", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChampionshipId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChampionshipsAdmins", "UserId", "dbo.Championship");
            DropForeignKey("dbo.ChampionshipsAdmins", "ChampionshipId", "dbo.User");
            DropForeignKey("dbo.Competition", "Championship_Id", "dbo.Championship");
            DropForeignKey("dbo.FishermenCompetitions", "FishermanId", "dbo.Fisherman");
            DropForeignKey("dbo.FishermenCompetitions", "CompetitionId", "dbo.Competition");
            DropIndex("dbo.ChampionshipsAdmins", new[] { "UserId" });
            DropIndex("dbo.ChampionshipsAdmins", new[] { "ChampionshipId" });
            DropIndex("dbo.FishermenCompetitions", new[] { "FishermanId" });
            DropIndex("dbo.FishermenCompetitions", new[] { "CompetitionId" });
            DropIndex("dbo.User", "UX_User_FirstName_LastName");
            DropIndex("dbo.Competition", new[] { "Championship_Id" });
            DropTable("dbo.ChampionshipsAdmins");
            DropTable("dbo.FishermenCompetitions");
            DropTable("dbo.Championship");
            DropTable("dbo.User");
            DropTable("dbo.Fisherman");
            DropTable("dbo.Competition");
        }
    }
}
