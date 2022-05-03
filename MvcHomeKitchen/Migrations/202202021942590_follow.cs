namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class follow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowId = c.Int(nullable: false, identity: true),
                        TakipEden = c.Int(nullable: false),
                        TakipEdilen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Follows");
        }
    }
}
