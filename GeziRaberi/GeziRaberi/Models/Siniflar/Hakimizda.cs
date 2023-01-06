using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziRaberi.Models.Siniflar
{
    public class Hakimizda
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string FotoUrl { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Aciklama { get; set; }
    }
}