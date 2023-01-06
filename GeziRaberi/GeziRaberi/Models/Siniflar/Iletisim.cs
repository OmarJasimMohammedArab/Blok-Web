using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziRaberi.Models.Siniflar
{
    public class Iletisim
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Konu { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Mesaj { get; set; }
    }
}