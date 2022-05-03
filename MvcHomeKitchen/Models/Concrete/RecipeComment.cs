using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class RecipeComment
    {
        [Key]
        public int RecipeCommentId { get; set; }
        public string Context { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}