using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeMoMVCNetCore.Models
{
    public class Products
    {
        [Key]
        [Display(Name ="Id Sản Phẩm")]
        public string ProductID { get; set; }
        [Display(Name ="Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [Display(Name ="Unitprice")]
        public string Unitprice { get; set; }
        [Display(Name ="Số Lượng")]
        public string Quantity { get; set; }          
    }
}
