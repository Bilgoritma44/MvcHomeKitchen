namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abone2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Sayi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Sayi");
        }
    }
}
