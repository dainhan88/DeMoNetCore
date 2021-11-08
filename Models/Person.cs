using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Person
    {
        [Key]
        [Display(Name ="Id") ]
        public string PersonID { get; set; }
       
        public string PersonName { get; set; }
        public string Title { get; internal set; }
    }
}