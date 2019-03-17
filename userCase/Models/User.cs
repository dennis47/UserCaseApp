using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int userID { get; set; }
        [DisplayName("Ad"), StringLength(100)] //  [Column("varchar(30)")]
        public string name { get; set; }
        [DisplayName("Soyad"), StringLength(100)]
        public string surname { get; set; }
        [EmailAddress]
        [DisplayName("E-Posta"), Required(ErrorMessage = "Lütfen mail adresinizi giriniz."), StringLength(100)]
        public string email { get; set; }
        [DisplayName("Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime birthdate { get; set; } 
        [DisplayName("Şifre"),DataType(DataType.Password), Required(ErrorMessage = "Lütfen şifrenizi giriniz."), StringLength(100)]
        public string password { get; set; }
        public virtual int districtID { get; set; }
        public virtual District District { get; set; } 
        public virtual int cityID { get; set; }
        public virtual City City { get; set; }

    }
}
