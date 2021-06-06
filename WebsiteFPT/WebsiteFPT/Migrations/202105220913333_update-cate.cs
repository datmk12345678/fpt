namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categorys", "MetaTitle");
            DropColumn("dbo.Categorys", "ParentID");
            DropColumn("dbo.Categorys", "DisplayOder");
            DropColumn("dbo.Categorys", "SeoTitle");
            DropColumn("dbo.Categorys", "ShowOnHome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorys", "ShowOnHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categorys", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Categorys", "DisplayOder", c => c.Int(nullable: false));
            AddColumn("dbo.Categorys", "ParentID", c => c.Long(nullable: false));
            AddColumn("dbo.Categorys", "MetaTitle", c => c.String(maxLength: 250));
        }
    }
}
