using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziRaberi.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string KulaniciAdi { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Password { get; set; }
        public string Imge { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

       
    }
}