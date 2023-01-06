    using GeziRaberi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeziRaberi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context con = new Context();
        //Bloglar Yonetimi********************************//
        [Authorize]
        public ActionResult Index()
        {
            var deger = con.Blogs.ToList();
            return View(deger);
        }


        ///////Yeni Blog Eklemek
        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.BlogImage = "/Image/" + dAdi + duzanti;  
            }
            con.Blogs.Add(p);
            
                con.SaveChanges();       
                return RedirectToAction("Index", "admin");
            }
            else
            {
                ViewBag.Message = "Hatalı Bilğilerinizi ve Boş Alanları Kontrol Edin ";
                return View();
            }

        }

        public ActionResult BlogSil(int id)
        {
            var b = con.Blogs.Find(id);
            con.Blogs.Remove(b);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var b1 = con.Blogs.Find(id);
            return View("BlogGetir", b1);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = con.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        //Yorumlar Yonetimi***************************************//
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = con.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var y = con.Yorumlars.Find(id);
            con.Yorumlars.Remove(y);
            con.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public ActionResult YorumGetir(int id)
        {
            var yr = con.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = con.Yorumlars.Find(y.ID);

            yrm.Yorum = y.Yorum;
            con.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        //İletişim Yönetimi////////////////////////////////////////
        [Authorize]
        public ActionResult IletisimList()
        {
            var deyer = con.Iletisims.ToList();
            return View(deyer);
        }

        public ActionResult MesajSil(int id)
        {
            var m = con.Iletisims.Find(id);
            con.Iletisims.Remove(m);
            con.SaveChanges();
            return RedirectToAction("IletisimList");
        }
    }
}