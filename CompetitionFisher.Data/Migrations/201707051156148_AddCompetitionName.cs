namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompetitionName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competition", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Championship", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Championship", "Name", c => c.String());
            DropColumn("dbo.Competition", "Name");
        }
    }
}
