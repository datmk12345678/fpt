namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_br : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Image", c => c.String());
            DropColumn("dbo.Brands", "Photos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "Photos", c => c.String());
            DropColumn("dbo.Brands", "Image");
        }
    }
}
