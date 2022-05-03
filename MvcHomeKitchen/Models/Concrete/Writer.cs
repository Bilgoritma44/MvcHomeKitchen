using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Follow { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<RecipeComment> RecipeComments { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
        public ICollection<RecipeBook> RecipeBooks { get; set; }
    }
}