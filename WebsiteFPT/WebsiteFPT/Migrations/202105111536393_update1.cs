namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Brands", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "Image", c => c.String());
        }
    }
}
