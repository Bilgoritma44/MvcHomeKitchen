namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wrtierphoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "PhotoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "PhotoUrl");
        }
    }
}
