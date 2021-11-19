using System.ComponentModel.DataAnnotations.Schema;

namespace DeMoMVCNetCore.Models{
    public class Product{
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

    }
}