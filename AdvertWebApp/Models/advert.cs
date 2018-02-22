using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvertWebApp.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string AdvertText { get; set; }
        public DateTime CreationTime { get; set; }
    }
}