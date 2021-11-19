using System.Collections.Generic;
using System.Net.NetworkInformation;
namespace DeMoMVCNetCore.Models{
    public class Category{
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}