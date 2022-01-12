namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lectures", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Lectures", "Tutor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lectures", "CourseId");
            CreateIndex("dbo.Lectures", "Tutor_Id");
            AddForeignKey("dbo.Lectures", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lectures", "Tutor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "Tutor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lectures", "CourseId", "dbo.Courses");
            DropIndex("dbo.Lectures", new[] { "Tutor_Id" });
            DropIndex("dbo.Lectures", new[] { "CourseId" });
            DropColumn("dbo.Lectures", "Tutor_Id");
            DropColumn("dbo.Lectures", "CourseId");
        }
    }
}
