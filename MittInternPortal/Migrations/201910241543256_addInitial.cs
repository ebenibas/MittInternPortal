namespace MittInternPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Students", new[] { "InstructorId" });
            AddColumn("dbo.Students", "Instructor_Id", c => c.Int());
            AddColumn("dbo.Students", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Students", "InstructorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "InstructorId");
            CreateIndex("dbo.Students", "Instructor_Id");
            CreateIndex("dbo.Students", "ApplicationUser_Id");
            AddForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Students", "Instructor_Id", "dbo.Instructors", "Id");
            AddForeignKey("dbo.Students", "InstructorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "InstructorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Students", new[] { "Instructor_Id" });
            DropIndex("dbo.Students", new[] { "InstructorId" });
            AlterColumn("dbo.Students", "InstructorId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "ApplicationUser_Id");
            DropColumn("dbo.Students", "Instructor_Id");
            CreateIndex("dbo.Students", "InstructorId");
            AddForeignKey("dbo.Students", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
