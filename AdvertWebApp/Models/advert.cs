using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvertWebApp.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        [DisplayName("Advert price EUR")]
        [Required(ErrorMessage = "Lauks {0} ir vajadzigs")]
        public double Price { get; set; }
        [DisplayName("Advert name")]
        public string Name { get; set; }
        [DisplayName("Advert text")]
        [StringLength(100, MinimumLength = 3)]
        public string AdvertText { get; set; }
        public DateTime CreationTime { get; set; }
    }
}