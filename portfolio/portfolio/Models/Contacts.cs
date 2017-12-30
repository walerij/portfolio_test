using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.Models
{
    public class Contacts
    {
        //Contacts
           [Key]
           public int id { get; set; }
           [Display(Name ="Параметр")]
           public string param { get; set; }
           [Display(Name ="Значение")]
           public string value { get; set; }
    }
}