using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string Person { get; set; }
        public string Preparation { get; set; }
        public string Cooking { get; set; }
        public bool Status { get; set; }
        public int  Sayi { get; set; }
        public int  YorumSayi { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<RecipeComment> RecipeComments { get; set; }
    }
}