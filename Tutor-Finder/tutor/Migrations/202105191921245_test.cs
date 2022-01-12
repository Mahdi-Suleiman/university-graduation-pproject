namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyPlaces", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyPlaces", "Image", c => c.String(nullable: false));
        }
    }
}
