using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class SocialLinks
    {
        [Key]
        public int id { get; set; }
        public string img_name{ get; set; }
        public string link{ get; set; }
        public string title{ get; set; }
    }
}