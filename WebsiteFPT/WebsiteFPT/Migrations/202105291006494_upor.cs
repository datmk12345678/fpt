namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Id_Payment", "dbo.Payment_methods");
            DropForeignKey("dbo.Orders", "ID_Users", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "Id_Payment" });
            DropIndex("dbo.Orders", new[] { "ID_Users" });
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "Id_Payment");
            DropColumn("dbo.Orders", "ID_Users");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ID_Users", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Id_Payment", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Quantity", c => c.String(maxLength: 250));
            CreateIndex("dbo.Orders", "ID_Users");
            CreateIndex("dbo.Orders", "Id_Payment");
            AddForeignKey("dbo.Orders", "ID_Users", "dbo.Users", "ID_Users", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Id_Payment", "dbo.Payment_methods", "Id_Payment", cascadeDelete: true);
        }
    }
}
