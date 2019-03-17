using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{
    [Table("districts")]
    public class District
    {
        [Key]
        public int districtID { get; set; }
        [DisplayName("ilçe Kodu"), StringLength(100)]
        public int districtCode { get; set; }
        [DisplayName("ilçe"), StringLength(100)]
        public string districtName { get; set; }
        public int cityID { get; set; }
        //[ForeignKey("cityID")]
        //public virtual City City { set; get; }
        public virtual List<User> Users { set; get; }
    }
}
