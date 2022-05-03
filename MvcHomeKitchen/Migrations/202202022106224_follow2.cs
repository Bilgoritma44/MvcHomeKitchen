namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class follow2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Follows", "IsTakip", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Follows", "IsTakip");
        }
    }
}
