namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_orde : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "payment_method");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "payment_method", c => c.Int(nullable: false));
        }
    }
}
