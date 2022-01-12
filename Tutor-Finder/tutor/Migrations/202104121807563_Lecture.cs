namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TutorId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        StudyPlaceId = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .ForeignKey("dbo.StudyPlaces", t => t.StudyPlaceId, cascadeDelete: true)
                .Index(t => t.StudyPlaceId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.StudyPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 13),
                        Location = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "StudyPlaceId", "dbo.StudyPlaces");
            DropForeignKey("dbo.Lectures", "Student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Lectures", new[] { "Student_Id" });
            DropIndex("dbo.Lectures", new[] { "StudyPlaceId" });
            DropTable("dbo.StudyPlaces");
            DropTable("dbo.Lectures");
            DropTable("dbo.Courses");
        }
    }
}
