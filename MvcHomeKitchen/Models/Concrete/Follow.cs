using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }
        public int TakipEden { get; set; }
        public int TakipEdilen { get; set; }
        public bool IsTakip { get; set; }
    }
}