namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_something : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Order_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Order_Code", c => c.String(maxLength: 10));
        }
    }
}
