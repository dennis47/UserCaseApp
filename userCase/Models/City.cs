using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{
    [Table("cities")]
    public class City
    {
        [Key]
        public int cityID { get; set; }
        [DisplayName("il Kodu")]
        public int cityCode { get; set; }
        [DisplayName("il"), StringLength(100)]
        public string cityName { get; set; }
        public virtual List<User> Users { get; set; }
        //public virtual List<District> Districts { get; set; }

    }
}
