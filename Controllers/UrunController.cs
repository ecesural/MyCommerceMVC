using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCommerce.Models;
using MyCommerce.App_Start;
using static MyCommerce.ViewModels.Sepet;
using MyCommerce.ViewModels;

namespace MyCommerce.Controllers
{
    [KullaniciFilter]
    public class UrunController : Controller
    {
        Northwind2Entities data = new Northwind2Entities();
        // GET: Urun
        public ActionResult Detay(int id)
        {
            Urunler currentUrun = data.Urunler.Find(id);            
            return View(currentUrun);
        }
        [HttpPost]
        public void SepetEkle(int id)
        {
            SepetUrunu sepetUrunu = new SepetUrunu();
            Urunler urun = data.Urunler.Find(id);
            sepetUrunu.Urun = urun;
            sepetUrunu.Adet = 1;
            Sepet sptBase = new Sepet();
            sptBase.SepetEkle(sepetUrunu);
        }

        public ActionResult Sepet()
        {
            if (HttpContext.Session["sepettemi"] != null)
                return View(HttpContext.Session["sepettemi"] as Sepet);
            else
                return View();
        }

    }
}