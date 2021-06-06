namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_prcte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategory", "ID_Category", "dbo.Categorys");
            DropForeignKey("dbo.ProductCategory", "ID_Product", "dbo.Products");
            DropIndex("dbo.ProductCategory", new[] { "ID_Category" });
            DropIndex("dbo.ProductCategory", new[] { "ID_Product" });
            AddColumn("dbo.Products", "ID_Category", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ID_Category");
            AddForeignKey("dbo.Products", "ID_Category", "dbo.Categorys", "ID_Category", cascadeDelete: true);
            DropTable("dbo.ProductCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID_ProductCategory = c.Int(nullable: false, identity: true),
                        ParentID = c.Long(nullable: false),
                        ID_Category = c.Int(nullable: false),
                        ID_Product = c.Int(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ProductCategory);
            
            DropForeignKey("dbo.Products", "ID_Category", "dbo.Categorys");
            DropIndex("dbo.Products", new[] { "ID_Category" });
            DropColumn("dbo.Products", "ID_Category");
            CreateIndex("dbo.ProductCategory", "ID_Product");
            CreateIndex("dbo.ProductCategory", "ID_Category");
            AddForeignKey("dbo.ProductCategory", "ID_Product", "dbo.Products", "ID_Product", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategory", "ID_Category", "dbo.Categorys", "ID_Category", cascadeDelete: true);
        }
    }
}
