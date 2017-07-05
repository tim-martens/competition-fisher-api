namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChampionshipToCompetition : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Competition", name: "Championship_Id", newName: "ChampionshipId");
            RenameIndex(table: "dbo.Competition", name: "IX_Championship_Id", newName: "IX_ChampionshipId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Competition", name: "IX_ChampionshipId", newName: "IX_Championship_Id");
            RenameColumn(table: "dbo.Competition", name: "ChampionshipId", newName: "Championship_Id");
        }
    }
}
