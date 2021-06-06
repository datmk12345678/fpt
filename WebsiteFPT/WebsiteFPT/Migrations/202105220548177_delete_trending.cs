namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_trending : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ID_Trending", "dbo.Trendings");
            DropIndex("dbo.Products", new[] { "ID_Trending" });
            DropColumn("dbo.Products", "ID_Trending");
            DropTable("dbo.Trendings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trendings",
                c => new
                    {
                        ID_Trending = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Trending);
            
            AddColumn("dbo.Products", "ID_Trending", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ID_Trending");
            AddForeignKey("dbo.Products", "ID_Trending", "dbo.Trendings", "ID_Trending", cascadeDelete: true);
        }
    }
}
