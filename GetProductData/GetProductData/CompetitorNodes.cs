using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace GetProductData
{
    public class CompetitorNodes
    {

        public class ProductNodesByCompetitors
        {

            
            string descriptionNodes = "/html//div//div//div//div//div//div//div//div//div//div//p/a";
            string actionPriceNodes = "/html//div//div//div//div/div//div//div/div//div//div/div//span//span[1]";
            string regularPriceNodes = "/html//div//div//div//div/div//div//div//div//div//div/div[1]/span[2]";
            string discountNodes = "/html//div//div//div//div/div//div//div//div//div//div/div[3]";

        }
    }
}
