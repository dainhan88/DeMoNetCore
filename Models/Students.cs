using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Students
    {
        [Key]
        [Display(Name ="ID Sinh Viên")]
        public string StudenID { get; set; }
        [Display(Name ="Họ Và Tên")]
        public string StudentName { get; set; }        
    }
}