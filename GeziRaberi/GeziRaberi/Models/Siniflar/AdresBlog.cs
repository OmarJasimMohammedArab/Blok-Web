using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziRaberi.Models.Siniflar
{
    public class AdresBlog
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string AdresAcik { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Konum { get; set; }
    }
}