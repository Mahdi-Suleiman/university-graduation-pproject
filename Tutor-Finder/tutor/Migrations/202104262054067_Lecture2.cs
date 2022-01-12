namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Lectures", new[] { "Student_Id" });
            DropIndex("dbo.Lectures", new[] { "Tutor_Id" });
            DropColumn("dbo.Lectures", "StudentId");
            DropColumn("dbo.Lectures", "TutorId");
            RenameColumn(table: "dbo.Lectures", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.Lectures", name: "Tutor_Id", newName: "TutorId");
            AlterColumn("dbo.Lectures", "TutorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Lectures", "StudentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lectures", "TutorId");
            CreateIndex("dbo.Lectures", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lectures", new[] { "StudentId" });
            DropIndex("dbo.Lectures", new[] { "TutorId" });
            AlterColumn("dbo.Lectures", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lectures", "TutorId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Lectures", name: "TutorId", newName: "Tutor_Id");
            RenameColumn(table: "dbo.Lectures", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.Lectures", "TutorId", c => c.Int(nullable: false));
            AddColumn("dbo.Lectures", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lectures", "Tutor_Id");
            CreateIndex("dbo.Lectures", "Student_Id");
        }
    }
}
