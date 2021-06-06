namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_PROD : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Products", "Guarantee", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Guarantee", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
        }
    }
}
