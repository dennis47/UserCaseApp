using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{
    public class LoginViewModel
    {
        [DisplayName("E-Posta"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(50, ErrorMessage =
             "{0} max. {1}  karater olmalı")]
        public string email { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez"), DataType(DataType.Password), StringLength(50, ErrorMessage =
           "{0} max. {1}  karater olmalı")]
        public string password { get; set; }
    }
}
