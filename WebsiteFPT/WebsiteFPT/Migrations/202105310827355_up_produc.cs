namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_produc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Hot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Gioitinh", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Gioitinh");
            DropColumn("dbo.Products", "Hot");
        }
    }
}
