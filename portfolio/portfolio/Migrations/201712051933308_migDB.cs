namespace portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "login", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "passw", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "passw", c => c.String());
            AlterColumn("dbo.Users", "login", c => c.String());
        }
    }
}
