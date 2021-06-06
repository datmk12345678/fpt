namespace WebsiteFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_about1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Image");
        }
    }
}
