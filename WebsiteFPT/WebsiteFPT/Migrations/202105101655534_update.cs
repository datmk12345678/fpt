namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID_About = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_About);
            
            CreateTable(
                "dbo.attr_orders",
                c => new
                    {
                        ID_attr_order = c.Int(nullable: false, identity: true),
                        Color = c.String(maxLength: 250),
                        Size = c.String(maxLength: 250),
                        Status = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ID_Order = c.Int(nullable: false),
                        ID_Product = c.Int(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_attr_order)
                .ForeignKey("dbo.Orders", t => t.ID_Order, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ID_Product, cascadeDelete: true)
                .Index(t => t.ID_Order)
                .Index(t => t.ID_Product);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID_Order = c.Int(nullable: false, identity: true),
                        Order_Code = c.String(maxLength: 10),
                        Note = c.String(maxLength: 250),
                        Quantity = c.String(maxLength: 250),
                        Total_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(storeType: "ntext"),
                        ID_Guest = c.Int(nullable: false),
                        Id_Payment = c.Int(nullable: false),
                        ID_Users = c.Int(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Order)
                .ForeignKey("dbo.Guests", t => t.ID_Guest, cascadeDelete: true)
                .ForeignKey("dbo.Payment_methods", t => t.Id_Payment, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ID_Users, cascadeDelete: true)
                .Index(t => t.ID_Guest)
                .Index(t => t.Id_Payment)
                .Index(t => t.ID_Users);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID_Guest = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        ComfirmPassWord = c.String(),
                    })
                .PrimaryKey(t => t.ID_Guest);
            
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID_Users = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false),
                        ComfirmPassWord = c.String(),
                        Address = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(maxLength: 50),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Users);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID_Product = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Code = c.String(maxLength: 10),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        Image1 = c.String(maxLength: 250),
                        Image2 = c.String(maxLength: 250),
                        Image3 = c.String(maxLength: 250),
                        ID_Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ID_Brand = c.Int(nullable: false),
                        ID_Trending = c.Int(nullable: false),
                        Detail = c.String(storeType: "ntext"),
                        Guarantee = c.String(maxLength: 500),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Product)
                .ForeignKey("dbo.Brands", t => t.ID_Brand, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.ID_Price, cascadeDelete: true)
                .ForeignKey("dbo.Trendings", t => t.ID_Trending, cascadeDelete: true)
                .Index(t => t.ID_Price)
                .Index(t => t.ID_Brand)
                .Index(t => t.ID_Trending);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID_Brand = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Brand);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID_Price = c.Int(nullable: false, identity: true),
                        Prices = c.Int(nullable: false),
                        PromotionPrice = c.Int(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Price);
            
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
            
            CreateTable(
                "dbo.Categorys",
                c => new
                    {
                        ID_Category = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        ParentID = c.Long(nullable: false),
                        DisplayOder = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Category);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID_Contact = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Contact);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ID_Content = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        ID_Category = c.Int(nullable: false),
                        Detail = c.String(storeType: "ntext"),
                        Guarantee = c.Int(nullable: false),
                        Status = c.Boolean(),
                        TopHot = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 500),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Content)
                .ForeignKey("dbo.Categorys", t => t.ID_Category, cascadeDelete: true)
                .Index(t => t.ID_Category);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID_Feedback = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        ID_Guest = c.Int(nullable: false),
                        ID_Users = c.Int(nullable: false),
                        Content = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Feedback)
                .ForeignKey("dbo.Guests", t => t.ID_Guest, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ID_Users, cascadeDelete: true)
                .Index(t => t.ID_Guest)
                .Index(t => t.ID_Users);
            
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
                .PrimaryKey(t => t.ID_ProductCategory)
                .ForeignKey("dbo.Categorys", t => t.ID_Category, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ID_Product, cascadeDelete: true)
                .Index(t => t.ID_Category)
                .Index(t => t.ID_Product);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID_Sale = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        ID_Product = c.Int(nullable: false),
                        Color = c.String(maxLength: 250),
                        Size = c.String(maxLength: 250),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Sale)
                .ForeignKey("dbo.Products", t => t.ID_Product, cascadeDelete: true)
                .Index(t => t.ID_Product);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID_Slider = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(nullable: false),
                        Link = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Slider);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ID_Product", "dbo.Products");
            DropForeignKey("dbo.ProductCategory", "ID_Product", "dbo.Products");
            DropForeignKey("dbo.ProductCategory", "ID_Category", "dbo.Categorys");
            DropForeignKey("dbo.Feedback", "ID_Users", "dbo.Users");
            DropForeignKey("dbo.Feedback", "ID_Guest", "dbo.Guests");
            DropForeignKey("dbo.Content", "ID_Category", "dbo.Categorys");
            DropForeignKey("dbo.attr_orders", "ID_Product", "dbo.Products");
            DropForeignKey("dbo.Products", "ID_Trending", "dbo.Trendings");
            DropForeignKey("dbo.Products", "ID_Price", "dbo.Prices");
            DropForeignKey("dbo.Products", "ID_Brand", "dbo.Brands");
            DropForeignKey("dbo.attr_orders", "ID_Order", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ID_Users", "dbo.Users");
            DropForeignKey("dbo.Orders", "Id_Payment", "dbo.Payment_methods");
            DropForeignKey("dbo.Orders", "ID_Guest", "dbo.Guests");
            DropIndex("dbo.Sales", new[] { "ID_Product" });
            DropIndex("dbo.ProductCategory", new[] { "ID_Product" });
            DropIndex("dbo.ProductCategory", new[] { "ID_Category" });
            DropIndex("dbo.Feedback", new[] { "ID_Users" });
            DropIndex("dbo.Feedback", new[] { "ID_Guest" });
            DropIndex("dbo.Content", new[] { "ID_Category" });
            DropIndex("dbo.Products", new[] { "ID_Trending" });
            DropIndex("dbo.Products", new[] { "ID_Brand" });
            DropIndex("dbo.Products", new[] { "ID_Price" });
            DropIndex("dbo.Orders", new[] { "ID_Users" });
            DropIndex("dbo.Orders", new[] { "Id_Payment" });
            DropIndex("dbo.Orders", new[] { "ID_Guest" });
            DropIndex("dbo.attr_orders", new[] { "ID_Product" });
            DropIndex("dbo.attr_orders", new[] { "ID_Order" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Sales");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Feedback");
            DropTable("dbo.Content");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categorys");
            DropTable("dbo.Trendings");
            DropTable("dbo.Prices");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Payment_methods");
            DropTable("dbo.Guests");
            DropTable("dbo.Orders");
            DropTable("dbo.attr_orders");
            DropTable("dbo.Abouts");
        }
    }
}
