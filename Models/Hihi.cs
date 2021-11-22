using System.ComponentModel.DataAnnotations.Schema;

namespace DeMoMVCNetCore.Models{
    public class HiHi{
        public int HiHiId { get; set; }
        public string HiHIname { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

    }
}