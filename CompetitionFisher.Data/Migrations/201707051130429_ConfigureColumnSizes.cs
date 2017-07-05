namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureColumnSizes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competition", "Date", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            DropColumn("dbo.Competition", "CompetitionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competition", "CompetitionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Competition", "Date");
        }
    }
}
