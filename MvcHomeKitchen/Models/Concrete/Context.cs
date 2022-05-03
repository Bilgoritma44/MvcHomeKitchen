using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Context:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeComment> RecipeComments { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<RecipeBook> RecipeBooks { get; set; }
        public DbSet<AddBook> AddBooks { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Calori> Caloris { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}