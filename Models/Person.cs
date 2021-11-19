using System.ComponentModel.DataAnnotations.Schema;

namespace DeMoMVCNetCore.Models{

    [Table("people")]
    public class Person{
        
        public int PerSonID { get; set; }
        public string FullName { get; set; }
    }
}