namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TutorCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TutorCourses",
                c => new
                    {
                        TutorId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TutorId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TutorId, cascadeDelete: true)
                .Index(t => t.TutorId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Course_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TutorCourses", "TutorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TutorCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "Course_Id" });
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TutorCourses", new[] { "CourseId" });
            DropIndex("dbo.TutorCourses", new[] { "TutorId" });
            DropTable("dbo.ApplicationUserCourses");
            DropTable("dbo.TutorCourses");
        }
    }
}
