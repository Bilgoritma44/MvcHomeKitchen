namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        NewsletterId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.NewsletterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Newsletters");
        }
    }
}
