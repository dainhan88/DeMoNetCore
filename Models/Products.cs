using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Products
    {
        [Key]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unitprice { get; set; }
        public string Quantity { get; set; }          
    }
}
