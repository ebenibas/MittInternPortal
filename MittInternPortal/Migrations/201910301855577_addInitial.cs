namespace MittInternPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPosts", "EmployerId", "dbo.Employers");
            DropIndex("dbo.JobPosts", new[] { "EmployerId" });
            RenameColumn(table: "dbo.JobPosts", name: "ApplicationUser_Id", newName: "Employers_Id");
            RenameIndex(table: "dbo.JobPosts", name: "IX_ApplicationUser_Id", newName: "IX_Employers_Id");
            AlterColumn("dbo.JobPosts", "EmployerId", c => c.String());
            AddForeignKey("dbo.JobPosts", "Employers_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPosts", "Employers_Id", "dbo.AspNetUsers");
            AlterColumn("dbo.JobPosts", "EmployerId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.JobPosts", name: "IX_Employers_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.JobPosts", name: "Employers_Id", newName: "ApplicationUser_Id");
            CreateIndex("dbo.JobPosts", "EmployerId");
            AddForeignKey("dbo.JobPosts", "EmployerId", "dbo.Employers", "Id", cascadeDelete: true);
        }
    }
}
