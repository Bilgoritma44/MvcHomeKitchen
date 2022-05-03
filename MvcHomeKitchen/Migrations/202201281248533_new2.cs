namespace MvcHomeKitchen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        BlogCommentId = c.Int(nullable: false, identity: true),
                        Context = c.String(),
                        WriterId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogCommentId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: false)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: false)
                .Index(t => t.WriterId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        Context = c.String(),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: false)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.WriterId);
            
            CreateTable(
                "dbo.RecipeComments",
                c => new
                    {
                        RecipeCommentId = c.Int(nullable: false, identity: true),
                        Context = c.String(),
                        WriterId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeCommentId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: false)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: false)
                .Index(t => t.WriterId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Title = c.String(),
                        Context = c.String(),
                        Person = c.String(),
                        Preparation = c.String(),
                        Cooking = c.String(),
                        CategoryId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeComments", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Recipes", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.RecipeComments", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.BlogComments", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Recipes", new[] { "WriterId" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropIndex("dbo.RecipeComments", new[] { "RecipeId" });
            DropIndex("dbo.RecipeComments", new[] { "WriterId" });
            DropIndex("dbo.Blogs", new[] { "WriterId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.BlogComments", new[] { "WriterId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeComments");
            DropTable("dbo.Writers");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Admins");
        }
    }
}
