using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class BlogComment
    {
        [Key]
        public int BlogCommentId { get; set; }
        public string Context { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}