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
       
        [Display(Name ="Tên Thành Viên")]
        public string PersonName { get; set; }
        [Display(Name ="Tiêu Đề")]
        public string Title { get; internal set; }
    }
}