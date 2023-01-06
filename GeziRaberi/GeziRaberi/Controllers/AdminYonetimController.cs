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
    public class AdminYonetimController : Controller
    {
        // GET: AdminYonetim
        Context con = new Context();
      [Authorize]
        public ActionResult Index()
        {
            var deyerler = con.Admins.ToList();
            return View(deyerler);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var deyer = con.Admins.Where(x => x.KulaniciAdi == ad.KulaniciAdi
              && x.Password == ad.Password
              && x.IsActive == true
              && x.IsAdmin == true).FirstOrDefault();
            if (deyer != null)
            {
                FormsAuthentication.SetAuthCookie(ad.KulaniciAdi, false);
                Session["Login"] = deyer.KulaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Hatalı Giriş";
                return View();
            }

        }

        public ActionResult Partial1()
        {
            string uy = HttpContext.User.Identity.Name;
            List<Admin> deyer = con.Admins.Where(x => x.KulaniciAdi == uy).ToList();
            return PartialView(deyer);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniAdmin(Admin p)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.Imge = "/Image/" + dAdi + duzanti;
            }
            con.Admins.Add(p);
           
                con.SaveChanges();
                ViewBag.Message = "Mesahjınız başarılı Gönderilmiştir";
                return RedirectToAction("Index", "AdminYonetim");
            }
            else
            {
                ViewBag.Message = "Hatalı Bilğilerinizi ve Boş Alanları Kontrol Edin ";
                return View();
            }
           

        }


        public ActionResult AdminSil(int id)
        {
            var ad = con.Admins.Find(id);
            con.Admins.Remove(ad);
            con.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AdminUp(int id)
        {
            var adm = con.Admins.Find(id);
            return View("AdminUp", adm);
        }

        public ActionResult AdminUpdate(Admin u)
        {
            var a = con.Admins.Find(u.ID);
            a.KulaniciAdi = u.KulaniciAdi;
            a.AdSoyad=u.AdSoyad;
            a.Mail = u.Mail;
            a.Telephone = u.Telephone;
            a.Password = u.Password;
            a.Imge = u.Imge;
            a.IsActive = u.IsActive;
            a.IsAdmin = u.IsAdmin;
            con.SaveChanges();
            return RedirectToAction("Index");
        }



        /// About Listesi////////////////////////////////////////
        /// 
        [Authorize]
        public ActionResult HakimizdaList()
        {
            var Hak = con.Hakimizdas.ToList();
            return View(Hak);

        }


        [Authorize]
        public ActionResult Hakimizda(Hakimizda H)
        {


            if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                H.FotoUrl = "/Image/" + dAdi + duzanti;
            }
            con.Hakimizdas.Add(H);
            if (ModelState.IsValid)
            {
                con.SaveChanges();
                return RedirectToAction("HakimizdaList", "AdminYonetim");
            }
            else
            {
                ViewBag.Message = "Hatalı Bilğilerinizi ve Boş Alanları Kontrol Edin ";
                return View();
            }

        }
        [HttpPost, ActionName("Index")]
        public ActionResult Logaut()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Login");
            return View("Login", "AdminYonetim");
        }
    }
}