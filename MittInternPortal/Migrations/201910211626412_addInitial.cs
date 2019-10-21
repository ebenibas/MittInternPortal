namespace MittInternPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Instructors", new[] { "ApplicationUserId" });
            DropColumn("dbo.Instructors", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Instructors", "ApplicationUserId");
            AddForeignKey("dbo.Instructors", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
