namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abone3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "YorumSayi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "YorumSayi");
        }
    }
}
