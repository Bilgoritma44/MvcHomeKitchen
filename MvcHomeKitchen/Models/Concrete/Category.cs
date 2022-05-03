using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}