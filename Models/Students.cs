using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Students
    {
        [Key]
        public string StudenID { get; set; }
        public string StudentName { get; set; }        
    }
}