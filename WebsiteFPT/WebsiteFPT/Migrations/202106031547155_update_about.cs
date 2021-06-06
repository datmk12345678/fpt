namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_about : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "Description", c => c.String(nullable: false, storeType: "ntext"));
            DropColumn("dbo.Abouts", "MetaTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "Description", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
