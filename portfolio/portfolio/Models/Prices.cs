using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class Prices
    {
       // Prices
           [Key]
           public int id { get; set; }
           public string name { get; set; }
           public string unit { get; set; }
           public double price { get; set; }
           public string info { get; set; }
    }
}