using AdvertWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Advert ad = GetAdvertFromDb(advertId);
            return View(ad);
        }

        private Advert GetAdvertFromDb(int advertId)
        {
            // proverjaem objavlenija, esli id sovpadaet s tem chto zaprosil user, vidaem 
            foreach (var ad in advertDb.Adverts)
            {
                if (ad.AdvertId == advertId)
                {
                    // vidaem objavlenije
                    return ad;
                }
                // tut otsebjachinu zaherachil



            }

            return null;
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

        public ActionResult EditAdvert(int advertId)
        {
            Advert editableAdvert = GetAdvertFromDb(advertId);
            return View(editableAdvert);
        }

        [HttpPost]
        public ActionResult EditAdvert(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return View(advert);
            }
            advertDb.Entry(advert).State = EntityState.Modified;
            advertDb.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}