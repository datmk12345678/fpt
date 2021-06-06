namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_brand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Photos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "Photos");
        }
    }
}
