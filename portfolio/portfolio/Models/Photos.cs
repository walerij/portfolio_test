using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.Models
{
    public class Photos
    {
   //     Photos
      [Key]
      public int id { get; set; }
      public int work_id { get; set; }
      public string link { get; set; }
      public string info { get; set; }

        [ForeignKey("work_id")]
        public virtual Works work { get; set; }
    }
}