using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCommerce.ViewModels
{
    public class UserViewModel
    {
        [StringLength(30), MaxLength(30, ErrorMessage ="Lütfen {1} karakteri geçmeyiniz."),Display(Name ="Kullanıcı Adı:")]
        public string KullaniciAdi { get; set; }

        [StringLength(30), MaxLength(30, ErrorMessage = "Lütfen {1} karakteri geçmeyiniz."), Display(Name = "Şifre:"), DataType(DataType.Password)]
        public string Parola { get; set; }
    }
}