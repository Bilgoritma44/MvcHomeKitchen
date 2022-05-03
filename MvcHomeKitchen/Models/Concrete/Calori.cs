using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcHomeKitchen.Models.Concrete
{
    public class Calori
    {
        [Key]
        public int CaloriId { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
    }
}