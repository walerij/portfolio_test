using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.Models
{
    public class Works
    {
        //  Works
          [Key]
           public int id { get; set; }
           
           public int topics_id { get; set; }
           public string title { get; set; }
           public string info { get; set; }
           public string link { get; set; }

        [ForeignKey("topics_id")]
        public virtual Topics topic { get; set; }
        public virtual ICollection<Photos> photos { get; set; }

    }
}