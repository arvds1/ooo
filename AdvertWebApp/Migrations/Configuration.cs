namespace AdvertWebApp.Migrations
{
    using AdvertWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdvertWebApp.Models.AdvertDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdvertWebApp.Models.AdvertDb context)
        {
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

            context.Adverts.AddOrUpdate(ad);
            context.Adverts.AddOrUpdate(HomeAd);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
