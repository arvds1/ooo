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
            advertDb = new AdvertDb();
        }


        private List<Advert> adverts;
        private AdvertDb advertDb;
   
        // eta funkcija vizivaet putj k stranice 
        // GET: Home (naprimer ss.lv) 
        public ActionResult Index()
        {
            // eta funkcija vizivaet html rezuljtat iz nashego index.cshtml faila
            // otsjuda podajem objavlenija
            return View(advertDb.Adverts.ToList());

        }

        public ActionResult Advert(int advertId)
        {
            // proverjaem objavlenija, esli id sovpadaet s tem chto zaprosil user, vidaem 
            foreach (var ad in advertDb.Adverts)
            {
                if (ad.AdvertId == advertId)
                {
                    return View(ad);
                }

            }

            return View();


        }

        public ActionResult CreateAdvert()
        {
            return View();
        }

        // Http post govorit o tom chto mi ozhidaem chto user poshlet dannie
        [HttpPost]
        public ActionResult CreateAdvert(Advert advert)
        {
            advert.CreationTime = DateTime.Now;
            advertDb.Adverts.Add(advert);
            advertDb.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}