using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCommerce.Models;

namespace MyCommerce.ViewModels
{
    public class Sepet
    {

        public static Sepet AktifMi
        {
            get
            {
                HttpContext httpCntx = HttpContext.Current;
                if (httpCntx.Session["sepettemi"] == null)
                {
                    httpCntx.Session["sepettemi"] = new Sepet();
                }
                return httpCntx.Session["sepettemi"] as Sepet;
            }
        }

        public List<SepetUrunu> urunler = new List<SepetUrunu>();

        public void SepetEkle(SepetUrunu sp)
        {
            if (HttpContext.Current.Session["sepettemi"] != null)
            {
                Sepet sepet = HttpContext.Current.Session["sepettemi"] as Sepet;

                if (sepet.urunler.Any(x=>x.Urun.UrunID==sp.Urun.UrunID))
                {
                    sepet.urunler.
                        FirstOrDefault(x => x.Urun.UrunID == sp.Urun.UrunID).Adet++;
                }
                else
                {
                    sepet.urunler.Add(sp);
                }
            }
            else
            {
                Sepet sepet = new Sepet();
                sepet.urunler.Add(sp);
                HttpContext.Current.Session["sepettemi"] = sepet;
            }
        }

        public decimal? GenelToplam
        {
            get
            {
                return urunler.Sum(x => x.Tutar);
            }
        }

    }
    public class SepetUrunu
    {
        public Urunler Urun { get; set; }
        public int Adet { get; set; }
        public decimal? Tutar
        {
            get
            {
                return (decimal?)Adet * Urun.BirimFiyati;
            }
        }

    }
}