namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Abouts", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Abouts", "Name", c => c.String(maxLength: 250));
        }
    }
}
