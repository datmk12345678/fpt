namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_brand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "Image");
        }
    }
}
