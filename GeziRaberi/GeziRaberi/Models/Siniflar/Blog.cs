using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziRaberi.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}