namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddBooks",
                c => new
                    {
                        AddBookId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                        RecipeBookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddBookId);
            
            CreateTable(
                "dbo.RecipeBooks",
                c => new
                    {
                        RecipeBookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeBookId)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeBooks", "WriterId", "dbo.Writers");
            DropIndex("dbo.RecipeBooks", new[] { "WriterId" });
            DropTable("dbo.RecipeBooks");
            DropTable("dbo.AddBooks");
        }
    }
}
