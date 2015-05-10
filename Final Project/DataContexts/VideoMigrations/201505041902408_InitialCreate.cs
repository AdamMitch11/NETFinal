namespace Final_Project.DataContexts.VideoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Videos", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Videos", new[] { "CategoryID" });
            DropIndex("dbo.Videos", new[] { "AuthorID" });
            DropTable("dbo.Authors");
            DropTable("dbo.Videos");
            DropTable("dbo.Categories");
        }
    }
}
