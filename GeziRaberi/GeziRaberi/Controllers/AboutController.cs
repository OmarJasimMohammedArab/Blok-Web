using GeziRaberi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeziRaberi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context con = new Context();
        public ActionResult Index()
        {
            var degerler = con.Hakimizdas.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iletisim(Iletisim cont)
        {
            con.Iletisims.Add(cont);

            if (ModelState.IsValid)
            {
                con.SaveChanges();
                ViewBag.Message = "Mesahjınız başarılı Gönderilmiştir";
            }
            else
            {
                ViewBag.Message = "Hatalı! Bilğilerinizi ve Boş Alanları Kontrol Edin ";

            }
            return View();


        }

      
    }
}