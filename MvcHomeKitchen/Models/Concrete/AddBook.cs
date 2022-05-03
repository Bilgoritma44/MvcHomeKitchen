using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class AddBook
    {
        [Key]
        public int AddBookId { get; set; }
        public int RecipeId { get; set; }
        public int WriterId { get; set; }
        public int RecipeBookId { get; set; }
        
    }
}