namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_orderss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "payment_method", c => c.Int(nullable: false));
            DropTable("dbo.Payment_methods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payment_methods",
                c => new
                    {
                        Id_Payment = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Logo = c.String(maxLength: 250),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Payment);
            
            DropColumn("dbo.Orders", "payment_method");
        }
    }
}
