using GeziRaberi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GeziRaberi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        Context con = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [Route("Uye-Giris")]
        public ActionResult UyeG()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult UyeG(Admin uy)
        {
            var deyer = con.Admins.Where(x => x.KulaniciAdi == uy.KulaniciAdi
              && x.Password == uy.Password
              && x.IsActive == true
              && x.IsAdmin == false).FirstOrDefault();
            if(deyer!=null)
            {
                FormsAuthentication.SetAuthCookie(uy.KulaniciAdi, false);
                Session["UyeG"] = deyer.KulaniciAdi.ToString();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ViewBag.Error = "Hatalı Giriş";
                return View();
            }

        }

        [Route("Uye-Kayit")]
        public ActionResult UyeK()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult UyeK(Admin ka)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                ka.Imge = "/Image/" + dAdi + duzanti;
            }
            ka.IsActive = true;
            ka.IsAdmin = false;
            con.Admins.Add(ka);
           
                con.SaveChanges();
                ViewBag.Message = "Mesahjınız başarılı Gönderilmiştir";
                return Redirect("/Uye-Giris");
            }
            else
            {
                ViewBag.Message = "Hatalı Bilğilerinizi ve Boş Alanları Kontrol Edin ";
                return View();
            }
          
        }

        public ActionResult Profilim()
        {
            string uy = HttpContext.User.Identity.Name;
            List<Admin> deyer = con.Admins.Where(x => x.KulaniciAdi == uy).ToList();
            return View(deyer);
        }


    }
}