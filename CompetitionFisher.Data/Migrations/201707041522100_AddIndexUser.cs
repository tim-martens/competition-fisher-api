namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.User", new[] { "FirstName", "LastName" }, unique: true, name: "UX_User_FirstName_LastName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", "UX_User_FirstName_LastName");
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false));
        }
    }
}
