using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
namespace DeMoMVCNetCore.Models{
    public class Category{
        public int CategoryID { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage ="Bạn chỉ được chữ từ 3 - 60 ký tự")]
        public string CategoryName { get; set; }

        
        [Required(ErrorMessage ="Bạn bắt buộc phải viết chữ cái đầu viết hoa")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(100)]
        public string Categorynote { get; set; } 


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]  
        [Required(ErrorMessage ="Bạn chỉ được viết số từ 1 - 100 và trước dấu phẩy 18 ký tự và sau dấu , là 2 ký tự")]
        public decimal quantity { get; set; } 


      
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CategoryDate { get; set; }



        public string MovieGenre { get; set; }
        public string KeySearch { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<HiHi> HiHis { get; set; }
    }
}