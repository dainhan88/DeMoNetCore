using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Employees
    {
        [Key]
        [Display(Name ="ID Nhân Viên")]
        public string EmployeeID { get; set; }
        [Display(Name ="Họ Và Tên")]
        public string EmployeeName { get; set; }
         [Display(Name ="Số Điện Thoại")]
        public string PhoneNumber { get; set; }        
    }
}