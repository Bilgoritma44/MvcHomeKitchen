using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class RecipeBook
    {
        [Key]
        public int RecipeBookId { get; set; }
        public string BookName { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}