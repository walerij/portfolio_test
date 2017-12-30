namespace portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        param = c.String(),
                        value = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        work_id = c.Int(nullable: false),
                        link = c.String(),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Works", t => t.work_id, cascadeDelete: true)
                .Index(t => t.work_id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        topics_id = c.Int(nullable: false),
                        title = c.String(),
                        info = c.String(),
                        link = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Topics", t => t.topics_id, cascadeDelete: true)
                .Index(t => t.topics_id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        unit = c.String(),
                        price = c.Double(nullable: false),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        img_name = c.String(),
                        link = c.String(),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nick = c.String(),
                        login = c.String(),
                        passw = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "topics_id", "dbo.Topics");
            DropForeignKey("dbo.Photos", "work_id", "dbo.Works");
            DropIndex("dbo.Works", new[] { "topics_id" });
            DropIndex("dbo.Photos", new[] { "work_id" });
            DropTable("dbo.Users");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Prices");
            DropTable("dbo.Topics");
            DropTable("dbo.Works");
            DropTable("dbo.Photos");
            DropTable("dbo.Contacts");
        }
    }
}
