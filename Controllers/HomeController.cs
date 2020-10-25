using MyCommerce.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCommerce.Models;
using MyCommerce.ViewModels;

namespace MyCommerce.Controllers
{
    public class HomeController : Controller
    {
        Northwind2Entities db = new Northwind2Entities();



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel kullanici)
        {
            SiteUser user = db.SiteUser.SingleOrDefault(x =>
              x.UserName == kullanici.KullaniciAdi &&
              x.Password == kullanici.Parola
            );

            if (user == null)
            {
                return View();
            }
            else
            {
                Session["user"] = user;
                return RedirectToAction("Index");
            }


        }


        // GET: Home
        [KullaniciFilter]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getProducts()
        {
            List<Urunler> urunler = db.Urunler.Where(x => x.Sonlandi == false)
                .Take(6).ToList();
            return PartialView("_UrunlerPartial", urunler);
        }

        public ActionResult LogOut()
        {
            if (Session["User"] != null)
                Session["User"] = null;
            return RedirectToAction("Login");
        }


    }
}