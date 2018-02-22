using AdvertWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvertWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            adverts = new List<Advert>();
            Advert ad = new Advert();
            ad.AdvertId = 1;
            ad.Name = "bmw";
            ad.AdvertText = "buy my fantastic bmw";
            ad.Price = 15000.99;
            ad.CreationTime = DateTime.Now;

            Advert HomeAd = new Advert();
            HomeAd.AdvertId = 2;
            HomeAd.Name = "house";
            HomeAd.AdvertText = "buy my fantastic house";
            HomeAd.Price = 150000.99;
            HomeAd.CreationTime = new DateTime(1999, 12, 31);

            adverts.Add(ad);
            adverts.Add(HomeAd);
        }


        private List<Advert> adverts;
        // eta funkcija vizivaet putj k stranice 
        // GET: Home (naprimer ss.lv) 
        public ActionResult Index()
        {
            // eta funkcija vizivaet html rezuljtat iz nashego index.cshtml faila
            // otsjuda podajem objavlenija
            return View(adverts);

        }

        public ActionResult Advert(int advertId)
        {
            // proverjaem objavlenija, esli id sovpadaet s tem chto zaprosil user, vidaem 
            foreach (var ad in adverts)
            {
                if (ad.AdvertId == advertId)
                {
                    return View(ad);
                }

            }

            return View();
        }

        
    }
}