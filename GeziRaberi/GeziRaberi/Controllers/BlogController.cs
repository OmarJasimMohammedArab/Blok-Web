using GeziRaberi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeziRaberi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context con = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var bloglar = con.Blogs.ToArray();
            by.Deger1 = con.Blogs.ToList();
            by.Deger3 = con.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }

        //Blog Detay

        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = con.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = con.Yorumlars.Where(x => x.Blogid == id).ToList();
            //  var blogbul = con.Blogs.Where(x => x.ID ==id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYaz(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYaz(Yorumlar y)
        {
            con.Yorumlars.Add(y);
            con.SaveChanges();
            return PartialView();
        }

    }
}