namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abone4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caloris",
                c => new
                    {
                        CaloriId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PhotoUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CaloriId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Caloris");
        }
    }
}
