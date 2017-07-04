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
                        CompetitionId = c.Guid(nullable: false),
                        CompetitionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Fisherman",
                c => new
                    {
                        FishermanId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FishermanId);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        ResultId = c.Guid(nullable: false),
                        FishermanId = c.Guid(nullable: false),
                        CompetitionId = c.Guid(nullable: false),
                        NbrCaught = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Competition", t => t.CompetitionId)
                .ForeignKey("dbo.Fisherman", t => t.FishermanId)
                .Index(t => t.FishermanId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Result", "FishermanId", "dbo.Fisherman");
            DropForeignKey("dbo.Result", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.FishermenCompetitions", "FishermanId", "dbo.Fisherman");
            DropForeignKey("dbo.FishermenCompetitions", "CompetitionId", "dbo.Competition");
            DropIndex("dbo.FishermenCompetitions", new[] { "FishermanId" });
            DropIndex("dbo.FishermenCompetitions", new[] { "CompetitionId" });
            DropIndex("dbo.Result", new[] { "CompetitionId" });
            DropIndex("dbo.Result", new[] { "FishermanId" });
            DropTable("dbo.FishermenCompetitions");
            DropTable("dbo.User");
            DropTable("dbo.Result");
            DropTable("dbo.Fisherman");
            DropTable("dbo.Competition");
        }
    }
}
