using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio.Models
{
    public class Topics
    {
      public int id { get; set; }
      public string title { get; set; }
      public string info { get; set; }

      public virtual ICollection<Works> works { get; set; }
    }
}