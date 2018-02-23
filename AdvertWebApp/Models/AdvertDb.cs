using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdvertWebApp.Models
{
    public class AdvertDb : DbContext
    {
        public DbSet<Advert> Adverts { get; set; } 
    }
}