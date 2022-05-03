using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Context { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<BlogComment> BlogComments { get; set; }
    }
}