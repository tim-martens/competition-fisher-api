namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useraddemail : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.User", name: "UX_Competitor_FirstName_LastName", newName: "UX_User_FirstName_LastName");
            AddColumn("dbo.User", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Email");
            RenameIndex(table: "dbo.User", name: "UX_User_FirstName_LastName", newName: "UX_Competitor_FirstName_LastName");
        }
    }
}
