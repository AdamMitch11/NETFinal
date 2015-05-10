namespace Final_Project.DataContexts.VideoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "Title", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Videos", "VideoUrl", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "VideoUrl", c => c.String());
            AlterColumn("dbo.Videos", "Title", c => c.String());
        }
    }
}
