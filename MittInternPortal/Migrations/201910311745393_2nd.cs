namespace MittInternPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Title", c => c.String());
            AddColumn("dbo.Notifications", "DateSent", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "DateSent");
            DropColumn("dbo.Notifications", "Title");
        }
    }
}
